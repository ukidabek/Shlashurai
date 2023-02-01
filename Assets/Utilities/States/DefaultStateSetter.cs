using UnityEngine;

namespace Logic.States
{
    public class DefaultStateSetter : MonoBehaviour
    {
        [SerializeField] private GameObject _stateMachineHostingGameObject = null;
        private IStateMachine _stateManager = null;
        [SerializeField] private State _defaultState = null;

        private void Awake()
        {
            _stateManager = _stateMachineHostingGameObject.GetComponent<IStateMachine>();
        }

        private void Start()
        {
            _stateManager.EnterState(_defaultState);
        }
    }
}