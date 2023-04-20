using Shlashurai.Skill;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Skills
{
	[Serializable]
	public class SkillCost : ISkillCost
	{
		[SerializeField] private SkillCostDefinition[] m_cost = null;
		public IEnumerable<SkillCostDefinition> Cost => m_cost;

		[SerializeField] private float m_coolDownTime = 0;

		public float CoolDownTime => m_coolDownTime;

		[SerializeField] private float m_castTime = 0;
		public float CastTime => m_castTime;
	}
}