using System;
using System.Collections.Generic;

namespace Utilities.States
{
	public class StateMachine : IStateMachine
    {
        public event Action OnStateChange; 
        
        private readonly IEnumerable<IStateLogicExecutor> _stateLogicExecutor = null;
        private readonly IEnumerable<IStateTransitionLogic> _transitions = null;
        private readonly IEnumerable<IStatePreProcessor> _statePreProcessors = null;

		public IState CurrentState { get; private set; }

		public string Name { get; private set; }

		public IState PreviousState { get; private set; }

		public StateMachine(IEnumerable<IStateLogicExecutor> stateLogicExecutor, IEnumerable<IStateTransitionLogic> transitions, IEnumerable<IStatePreProcessor> statePreProcessor = null)
            : this(nameof(StateMachine), stateLogicExecutor, transitions, statePreProcessor)
		{
		}

		public StateMachine(string name, IEnumerable<IStateLogicExecutor> stateLogicExecutor, IEnumerable<IStateTransitionLogic> transitions, IEnumerable<IStatePreProcessor> statePreProcessor)
        {
            Name = name;
            _stateLogicExecutor = stateLogicExecutor;
            _transitions = transitions;
			_statePreProcessors = statePreProcessor;
		}

        public void EnterState(IState statToEnter)
        {
            if(CurrentState == statToEnter) return;

            PreviousState = CurrentState;

            foreach (var transition in _transitions)
            {
                transition.Cancel();
                transition.Perform(CurrentState, statToEnter);
            }

            CurrentState?.Exit();
            CurrentState = statToEnter;
            
            foreach (var stateLogicExecutor in _stateLogicExecutor) 
                stateLogicExecutor.SetLogicToExecute(CurrentState);

			foreach (var preProcessor in _statePreProcessors)
				preProcessor.PreProcessor(CurrentState);

			CurrentState?.Enter();
            OnStateChange?.Invoke();
        }
    }
}