using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace MapGeneration.BaseGenerator
{
	public class LevelGenerator : MonoBehaviour
	{
		[SerializeField] protected GenerationState _state = GenerationState.Finished;
		public GenerationState State { get { return _state; } }

		[SerializeField] protected List<Object> _InitializationObjectList = new List<Object>();
		protected List<IGenerationInitalization> _generationInitializationList = new List<IGenerationInitalization>();

		[SerializeField, Space] private int _phaseIndex = 0;
		public int PhaseIndex { get { return _phaseIndex; } }
		[SerializeField] protected List<Object> _phaseObjectList = new List<Object>();
		protected List<IGenerationPhase> _generationPhaseList = new List<IGenerationPhase>();

		[SerializeField, Space] protected List<Object> _generationData = new List<Object>();

		private Coroutine _currentCoroutine = null;

		[Space]
		public UnityEvent GenerationStarted = new UnityEvent();
		public UnityEvent GenerationCanceled = new UnityEvent();
		public UnityEvent GenerationPaused = new UnityEvent();
		public UnityEvent<int> PhaseCompleted = new UnityEvent<int>();
		public UnityEvent GenerationCompleted = new UnityEvent();

		private void Update()
		{
			switch (_state)
			{
				case GenerationState.Start:
					InitializeGenerator();

					if (_generationPhaseList.Count == 0)
					{
						_state = GenerationState.Finished;
						break;
					}

					_state = GenerationState.Generation;
					_phaseIndex = 0;
					StartPhase();
					break;

				case GenerationState.Generation:
					if (_generationPhaseList[_phaseIndex].IsDone)
					{
						PhaseCompleted.Invoke(_phaseIndex);

						if ((_generationPhaseList.Count - 1) == _phaseIndex)
						{
							_state = GenerationState.Finished;
						}
						else
						{
							_currentCoroutine = null;
							if (_generationPhaseList[_phaseIndex].Pause)
								PauseGeneration();
							else
								StartNextPhase();
						}
					}
					break;

				case GenerationState.Finished:
					enabled = false;
					if (_currentCoroutine != null)
						StopCoroutine(_currentCoroutine);
					_currentCoroutine = null;

					GenerationCompleted.Invoke();
					break;

				case GenerationState.Pause:
					break;
			}
		}

		protected virtual void InitializeGenerator()
		{
			_generationPhaseList.Clear();
			var phases = _phaseObjectList.OfType<IGenerationPhase>().Select(phase => { phase.IsDone = false; return phase; });
			_generationPhaseList.AddRange(phases);

			var initializers = _InitializationObjectList.OfType<IGenerationInitalization>();
			foreach (var initializer in initializers)
				initializer.Initialize(this, _generationData.ToArray());
		}

		public void StartGeneration()
		{
			_state = GenerationState.Start;
			enabled = true;

			GenerationStarted.Invoke();
		}

		public void CancelGeneration()
		{
			_state = GenerationState.Finished;
			enabled = false;

			if (_currentCoroutine != null)
				StopCoroutine(_currentCoroutine);

			GenerationCanceled.Invoke();
		}

		public void PauseGeneration()
		{
			enabled = false;
			_state = GenerationState.Pause;
			GenerationPaused.Invoke();
		}

		public void ResumeGeneration()
		{
			enabled = true;
			_state = GenerationState.Generation;

			StartNextPhase();
		}

		private void StartNextPhase()
		{
			_phaseIndex++;
			StartPhase();
		}

		private void StartPhase()
		{
			if (_currentCoroutine == null)
				_currentCoroutine = StartCoroutine(_generationPhaseList[_phaseIndex].Generate(this));
		}

		public T GetMetaDataObject<T>() where T : class => _generationData.OfType<T>().FirstOrDefault();
	}
}
