using UnityEngine;

namespace Logic.States
{
    public abstract class SwitchStateConditionBase : MonoBehaviour, ISwitchStateCondition
    {
        public abstract bool Condition { get; }
        public virtual void Activate() {}
        public virtual void Deactivate() {}
    }
}