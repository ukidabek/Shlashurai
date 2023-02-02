using UnityEngine;
using UnityEngine.Serialization;

namespace Utilities.States
{
    public class StateSetter : MonoBehaviour
    {
        [SerializeField] protected GameObject _stateMachineHostingGameObject = null;
        private IStateMachine _stateManager = null;
        [FormerlySerializedAs("_defaultState")] [SerializeField] protected State m_state = null;

        private void Awake()
        {
            _stateManager = _stateMachineHostingGameObject.GetComponent<IStateMachine>();
        }

        public void SetState()
        {
            _stateManager.EnterState(m_state);
        }
    }
}