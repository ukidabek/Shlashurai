using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Skills
{
	public abstract class SkillTemplateBase : Template<ISkill>
	{
		[SerializeField] protected Sprite m_image = null;
		[SerializeField] protected SkillCostTemplateBase m_skillConstTemplate = null;
		[SerializeField] protected SkillEffectTemplateBase[] m_skillEffects = null;

		protected virtual IEnumerable<ISkillEffect> GenerateSkillEffects()
			=> m_skillEffects.Select(effectTemplate => effectTemplate.Create()).ToList();

		protected virtual ISkillCost GenerateSkillCost() => m_skillConstTemplate.Create();
	}
}