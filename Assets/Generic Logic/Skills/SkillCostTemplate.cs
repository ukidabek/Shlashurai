using System;
using UnityEngine;

namespace Skills
{
	public class SkillCostTemplate : SkillCostTemplateBase
	{
		[Serializable]
		private class SkillCost : ISkillCost
		{
			[SerializeField] private float m_coolDownTime = 1f;
			public float CoolDownTime => m_coolDownTime;

			[SerializeField] private float m_castTime = 1f;

			public float CastTime => m_castTime;
		}

		[SerializeField] private SkillCost m_skillCost = new SkillCost();

		public override ISkillCost Create() => m_skillCost;
	}
}