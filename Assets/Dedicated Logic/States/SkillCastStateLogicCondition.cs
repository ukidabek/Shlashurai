using Skills;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.States
{
	public class SkillCastStateLogicCondition : StateLogic, ISwitchStateCondition
	{
		[SerializeField] private SkillCastManager m_skillCastManager = null;

		public bool Condition => !m_skillCastManager.Casting;
	}
}