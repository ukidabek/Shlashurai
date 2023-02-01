using Logic.States;
using UnityEngine;

namespace Shlashurai.Player.Logic
{
    public class AnimationTriggerStateTransitionLogic : StateTransitionLogicBase
    {
        [SerializeField] private Animator m_animator = null;
        [SerializeField] private string m_triggerName = null;
        private int m_triggerHahs = 0;

        protected override void Awake()
        {
            base.Awake();
            m_triggerHahs = Animator.StringToHash(m_triggerName);
        }

        protected override void Perform()
        {
            m_animator.SetTrigger(m_triggerHahs);
        }
    }
}