using Shlashurai.Skill;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillCost : ISkillCost
{
	[SerializeField] private SkillCostDefinition[] m_cost = null;
	public IEnumerable<SkillCostDefinition> Cost => m_cost;
}
