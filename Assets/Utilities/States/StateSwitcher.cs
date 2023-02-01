namespace Logic.States
{
    public class StateSwitcher
    {
        private readonly IStateMachine _stateMachine = null;
        private readonly IState _stateToEnter = null;

        public StateSwitcher(object stateMachine, object stateToEnter)
        {
            _stateMachine = stateMachine as IStateMachine;
            _stateToEnter = stateToEnter as IState;
        }

        public void Switch()
        {
            if(_stateToEnter == null || 
               _stateMachine == null || 
               _stateMachine.CurrentState == _stateToEnter) 
                return;
            
            _stateMachine.EnterState(_stateToEnter);
        }
    }
}