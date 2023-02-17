using Shlashurai.Characters;
using Shlashurai.Skill;
using System;
using System.Linq;
using UnityEngine;

public class SkillCostManager : MonoBehaviour, ISkilCostManager
{
	[SerializeField] private ResourceManager m_resourceManager = null;

	private Action m_action = null;

	public bool CanCast(ISkillCost skillCost)
	{
		var spellCost = skillCost as SkillCost;

		m_action = null;

		var canCost = spellCost.Cost.All(cost =>
		{
			var resource = m_resourceManager.GetResource(cost.Id);
			m_action += () => resource.Value -= cost.Cost;
			return resource.Value >= cost.Cost;
		});

		if (canCost == false) return false;

		m_action?.Invoke();

		return true;
	}
}