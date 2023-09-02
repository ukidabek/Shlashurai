using Shlashurai.Characters;
using Skills;
using System;
using System.Linq;
using UnityEngine;

namespace Shlashurai.Skills
{
	public class SkillCostManager : MonoBehaviour, ISkilCostManager
	{
		[SerializeField] private ResourceManager m_resourceManager = null;

		private Action m_action = null;

		public bool CanCast(ISkill skill)
		{
			var spellCost = skill.Cost as SkillCost;

			m_action = null;

			var enoughResources = spellCost.Cost.All(cost =>
			{
				var resource = m_resourceManager.GetResource(cost.Id);
				m_action += () => resource.Value -= cost.Cost;
				return resource.Value >= cost.Cost;
			});

			var hasCoolDownStatus = skill.Status.OfType<CoolDownSkillStatus>().Any();

			return enoughResources && !hasCoolDownStatus;
		}

		public void ApplyCost() => m_action?.Invoke();
	}
}