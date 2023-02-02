using System.Linq;
using UnityEngine;

namespace Utilities.States
{
    public class StateManager : MonoBehaviour, IStateMachine
    {
        [SerializeField] private State m_currentState = null;
        public IState CurrentState => m_currentState;

        [SerializeField] private Object[] m_logicExecutor;
        private StateMachine _stateMachine = null;

        [SerializeField] private Object[] m_stateTransitions = null;

        private void Awake()
        {
            _stateMachine = new StateMachine(
                m_logicExecutor.OfType<IStateLogicExecutor>(), 
                m_stateTransitions.OfType<IStateTransitionLogic>());
            _stateMachine.OnStateChange += OnStateChange;
        }

        private void OnStateChange() => m_currentState = _stateMachine.CurrentState as State;

        public void EnterState(IState statToEnter) => _stateMachine.EnterState(statToEnter);
    }
}
