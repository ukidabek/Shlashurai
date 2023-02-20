using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Skill
{
	[Serializable]
	public class SkillSlot
	{
		public event Action OnSkillChanged = null;

		private ISkill m_skill = null;
		public ISkill Skill
		{
			get => m_skill;
			set
			{
				if (m_skill == value) return;
				m_skill = value;
				OnSkillChanged?.Invoke();
			}
		}
	}

	public class SkillHolder : MonoBehaviour
	{
		[SerializeField] private int m_slotsCount = 4;
		private SkillSlot[] m_skillSlots = null;
		public IEnumerable<SkillSlot> SkillSlots => m_skillSlots;

		private void Awake()
		{
			m_skillSlots = new SkillSlot[m_slotsCount];
			for (int i = 0; i < m_slotsCount; i++)
				m_skillSlots[i] = new SkillSlot();
		}

		public SkillSlot GetSkillSlot(int slotIndex) => m_skillSlots[slotIndex];

		public void SetSkillToSlot(int slotIndex, ISkill skill) => m_skillSlots[slotIndex].Skill = skill;
	}
}