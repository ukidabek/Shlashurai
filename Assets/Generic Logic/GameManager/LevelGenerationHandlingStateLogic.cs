using MapGeneration.BaseGenerator;
using UnityEngine;
using Utilities.States;

public class LevelGenerationHandlingStateLogic : StateLogic, ISwitchStateCondition
{
	[SerializeField] private LevelGeneratorReferenceHost m_levelGeneratorReferenceHost = null;

	private LevelGenerator m_levelGenerator = null;

	public bool Condition => m_levelGenerator != null && m_levelGenerator.State == GenerationState.Finished;


	private void Awake()
	{
		m_levelGeneratorReferenceHost.OnReferenceChanged += HandleLevelGeneration;
	}

	private void OnDestroy()
	{
		m_levelGeneratorReferenceHost.OnReferenceChanged -= HandleLevelGeneration;
	}

	private void HandleLevelGeneration()
	{
		m_levelGenerator = m_levelGeneratorReferenceHost.Instance;
		if (m_levelGenerator == null) return;
		m_levelGenerator.StartGeneration();
	}
}