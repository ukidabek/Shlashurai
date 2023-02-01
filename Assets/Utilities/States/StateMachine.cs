using System;
using System.Collections.Generic;

namespace Logic.States
{
    public class StateMachine : IStateMachine
    {
        public event Action OnStateChange; 
        
        private readonly IEnumerable<IStateLogicExecutor> _stateLogicExecutor = null;
        private readonly IEnumerable<IStateTransitionLogic> _transitions = null;
        public IState CurrentState { get; private set; }

        public StateMachine(IEnumerable<IStateLogicExecutor> stateLogicExecutor, IEnumerable<IStateTransitionLogic> transitions)
        {
            _stateLogicExecutor = stateLogicExecutor;
            _transitions = transitions;
        }

        public void EnterState(IState statToEnter)
        {
            if(CurrentState == statToEnter) return;

            foreach (var transition in _transitions)
            {
                transition.Cancel();
                transition.Perform(CurrentState, statToEnter);
            }

            CurrentState?.Exit();
            CurrentState = statToEnter;
            
            foreach (var stateLogicExecutor in _stateLogicExecutor) 
                stateLogicExecutor.SetLogicToExecute(CurrentState);
            
            CurrentState?.Enter();
            OnStateChange?.Invoke();
        }
    }
}