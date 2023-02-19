using UnityEngine;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class BoolAnimationParametrSettingStateLogic : StateLogic
	{
        [SerializeField] private Animator m_animator = null;
        [SerializeField] private AnimatorParameterDefinition m_animatorParameterDefinition = null;

        [SerializeField] protected bool m_onActivateState = true;

		public override void Activate()
		{
			base.Activate();
            m_animatorParameterDefinition.SetBool(m_animator, m_onActivateState);
        }

		public override void Deactivate()
		{
			base.Deactivate();
			m_animatorParameterDefinition.SetBool(m_animator, !m_onActivateState);

		}
	}
}