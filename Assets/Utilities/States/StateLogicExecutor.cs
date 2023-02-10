using UnityEngine;

namespace Utilities.States
{
    public abstract class StateLogicExecutor : MonoBehaviour, IStateLogicExecutor
    {
        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }
        public abstract void SetLogicToExecute(IState state);
    }
}