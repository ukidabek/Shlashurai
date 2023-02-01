using UnityEngine;

namespace Logic.States
{
    public abstract class StateLogicExecutor : MonoBehaviour, IStateLogicExecutor
    {
        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }
        public abstract void ClearLogicToExecute();
        public abstract void SetLogicToExecute(IState state);
    }
}