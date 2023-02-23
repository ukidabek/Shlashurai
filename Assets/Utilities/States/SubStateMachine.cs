using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities.States
{
    public class SubStateMachine : StateLogic, IStateMachine
    {
        [SerializeField] private State _currentState = null;
        public IState CurrentState => _currentState;
        
        [SerializeField] private Object[] m_stateLogicExecutorsObjects = null;  
        [SerializeField] private Object[] m_stateTransitionObject;
        
        private StateMachine m_stateMachine;

        private IEnumerable<IStateLogicExecutor> m_stateLogicExecutors = null;

        [SerializeField] private StateSetter m_defaultStateSetter = null;

		private void CreateStateMachine()
		{
            if (m_stateMachine != null) return;

			m_stateLogicExecutors = m_stateLogicExecutorsObjects.OfType<IStateLogicExecutor>();

			m_stateMachine = new StateMachine(
			   m_stateLogicExecutors,
				m_stateTransitionObject.OfType<IStateTransitionLogic>());

			m_stateMachine.OnStateChange += StateMachineOnOnStateChange;

			m_defaultStateSetter?.SetState();
		}

		public override void Activate()
		{
            CreateStateMachine();
			foreach (var executor in m_stateLogicExecutors)
                executor.Enabled = true;
		}

		public override void Deactivate()
		{
			foreach (var executor in m_stateLogicExecutors)
				executor.Enabled = false;
		}

		private void StateMachineOnOnStateChange()
        {
            if (m_stateMachine.CurrentState is State state)
                _currentState = state;
        }

		public void EnterState(IState statToEnter) => m_stateMachine.EnterState(statToEnter);

        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }
    }
}