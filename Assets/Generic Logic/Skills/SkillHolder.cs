using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
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