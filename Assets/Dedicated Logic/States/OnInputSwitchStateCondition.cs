using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
    public abstract class OnInputSwitchStateCondition : SwitchStateConditionBase
    {
        [SerializeField] protected InputValues m_values = null;
        [SerializeField] protected bool m_inputStatus = false;

        public override void Deactivate()
        {
            base.Deactivate();
            Reset();
        }

        protected virtual void Reset() { }
    }
}