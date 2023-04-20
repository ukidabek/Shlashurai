using Shlashurai.Skill;
using UnityEngine;

namespace Shlashurai.Skills
{
	[CreateAssetMenu(menuName = "Skills/Templates/Cost/SkillCostTemplate", fileName = "SkillCostTemplate")]
	public class SkillCostTemplate : SkillCostTemplateBase
	{
		[SerializeField] private SkillCost m_skillConst = null;

		public override ISkillCost Create() => m_skillConst;
	}
}