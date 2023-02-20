using UnityEngine;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class SkillCastAnimationStateLogic : StateLogic
	{
		[SerializeField] private Animator m_animator = null;
		[SerializeField] private AnimatorParameterDefinition m_beginCastAnimatorParameter = null;
		[SerializeField] private AnimatorParameterDefinition m_endCastAnimatorParameter = null;

		public override void Activate()
		{
			base.Activate();
			m_beginCastAnimatorParameter.SetTrigger(m_animator);
		}

		public override void Deactivate()
		{
			base.Deactivate();
			m_endCastAnimatorParameter.SetTrigger(m_animator);
		}
	}
}