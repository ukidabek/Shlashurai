using System.Collections.Generic;

namespace Logic.States
{
    public interface IState
    {
        IEnumerable<IStateLogic> Logic { get; }
        void Enter();
        void Exit();
    }
}