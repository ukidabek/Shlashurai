namespace Logic.States
{
    public interface IStateLogicExecutor
    {
        bool Enabled { get; set; }
        void ClearLogicToExecute();
        void SetLogicToExecute(IState state);
    }
}