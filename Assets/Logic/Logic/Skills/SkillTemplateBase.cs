using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shlashurai.Skill
{
	public abstract class SkillTemplateBase : Template<ISkill>
	{
		[SerializeField] protected SkillEffectTemplateBase[] m_skillEffects = null;
		[SerializeField] protected SkillCostTemplateBase m_skillConstTemplate = null;

		protected virtual IEnumerable<ISkillEffect> GenerateSkillEffects() 
			=> m_skillEffects.Select(effectTemplate => effectTemplate.Create()).ToList();

		protected virtual ISkillCost GenerateSkillCost() => m_skillConstTemplate.Create();
	}
}