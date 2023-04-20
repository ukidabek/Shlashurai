using Utilities.States;
using UnityEngine;
using Shlashurai.Skill;
using Shlashurai.Input;

namespace Shlashurai.States
{
	public class SkillCastStateLogic : StateLogic, IOnUpdateLogic, ISwitchStateCondition
	{
		[SerializeField] private InputValues m_inputValues = null;
		[SerializeField] private SkillCastManager m_skillCastManager = null;
		[SerializeField] private SkillHolder m_skillHolder = null;

		private bool m_condition = false;
		public bool Condition => m_condition;

		public override void Activate()
		{
			base.Activate();
			m_condition = false;
		}

		public void OnUpdate(float deltaTime, float timeScale)
		{
			m_inputValues.Cast1 = Cast(m_inputValues.Cast1, m_skillHolder.GetSkillSlot(0).Skill);
			m_inputValues.Cast2 = Cast(m_inputValues.Cast2, m_skillHolder.GetSkillSlot(1).Skill);
		}

		private bool Cast(bool cast, ISkill skill)
		{
			if (cast)
			{
				m_skillCastManager.Cast(skill);
				m_condition = true;
				return false;
			}
			return cast;
		}
	}
}