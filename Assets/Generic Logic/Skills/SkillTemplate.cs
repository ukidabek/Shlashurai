using System;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
	[CreateAssetMenu(menuName = "Skills/Templates/SkillTemplate", fileName = "SkillTemplate")]
	public class SkillTemplate : SkillTemplateBase
	{
		private class Skill : ISkill
		{
			public Sprite Image { get; }
			public IEnumerable<ISkillEffect> Effects { get; }

			public ISkillCost Cost { get; }

			private List<ISkillStatus> m_status = new List<ISkillStatus>();

			public event Action<ISkillStatus> SkillStatusAdded;
			public event Action<ISkillStatus> SkillStatusRemoved;

			public IEnumerable<ISkillStatus> Status => m_status;

			public Skill(Sprite image, IEnumerable<ISkillEffect> effects, ISkillCost cost)
			{
				Image = image;
				Effects = effects;
				Cost = cost;
			}

			public void AddStatus(ISkillStatus status)
			{
				if (m_status.Contains(status)) return;
				m_status.Add(status);
				SkillStatusAdded?.Invoke(status);
			}

			public void RemoveStatus(ISkillStatus status)
			{
				if (m_status.Contains(status) == false) return;
				m_status.Remove(status);
				SkillStatusRemoved?.Invoke(status);
			}
		}

		public override ISkill Create()
		{
			var effects = GenerateSkillEffects();
			var cost = GenerateSkillCost();

			return new Skill(m_image, effects, cost);
		}
	}
}