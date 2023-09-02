using Shlashurai.Skills;
using Skills;
using UnityEngine;
using UnityEngine.UI;

namespace Shlashurai.UI
{
	public class SkillSlotDisplay : MonoBehaviour
	{
		[SerializeField] private Image m_foregroundImage = null;
		[SerializeField] private Image m_backgroundImage = null;

		private SkillSlot m_skillSlot = null;
		private ISkill m_currentSkill = null;

		private CoolDownSkillStatus m_coolDownStatus = null;

		public void Initialize(SkillSlot skillSlot)
		{
			m_skillSlot = skillSlot;
			m_skillSlot.OnSkillChanged += OnSkillChanged;
			OnSkillChanged();
		}

		private void OnSkillChanged()
		{
			if (m_currentSkill != null)
			{
				m_currentSkill.SkillStatusAdded -= SkillStatusAdded;
				m_currentSkill.SkillStatusRemoved -= SkillStatusRemoved;
			}

			m_currentSkill = m_skillSlot.Skill;

			if (m_currentSkill == null) return;

			m_foregroundImage.sprite = m_backgroundImage.sprite = m_currentSkill.Image;
			m_currentSkill.SkillStatusAdded += SkillStatusAdded;
			m_currentSkill.SkillStatusRemoved += SkillStatusRemoved;
		}

		private void SkillStatusAdded(ISkillStatus skillStatus)
		{
			if (skillStatus is CoolDownSkillStatus coolDownStatus)
			{
				m_coolDownStatus = coolDownStatus;
				m_coolDownStatus.OnCoolDownChanged += OnCoolDownChanged;
			}
		}

		private void OnCoolDownChanged(float percent) => m_foregroundImage.fillAmount = percent;

		private void SkillStatusRemoved(ISkillStatus obj)
		{
			if (obj is CoolDownSkillStatus coolDownStatus && m_coolDownStatus == coolDownStatus)
			{
				m_coolDownStatus.OnCoolDownChanged -= OnCoolDownChanged;
				OnCoolDownChanged(1f);
			}
		}
	}
}