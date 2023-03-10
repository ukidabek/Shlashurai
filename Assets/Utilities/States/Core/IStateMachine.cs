namespace Utilities.States
{
    public interface IStateMachine
    {
        IState CurrentState { get; }
        void EnterState(IState statToEnter);
    }
}