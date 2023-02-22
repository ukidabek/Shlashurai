using UnityEngine;
using UnityEngine.Serialization;

namespace Utilities.States
{
	public class StateSetter : MonoBehaviour
	{
#if UNITY_EDITOR
		[SerializeField] private string m_description;
#endif
		[SerializeField] protected Object _stateMachineObject = null;
		[FormerlySerializedAs("_defaultState")][SerializeField] protected State m_state = null;

		private IStateMachine _stateManager = null;

		public void SetState()
		{
			if (_stateManager == null)
				_stateManager = _stateMachineObject as IStateMachine;

			_stateManager.EnterState(m_state);
		}
	}
}