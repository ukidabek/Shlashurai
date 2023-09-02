using System;

namespace Skills
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
}