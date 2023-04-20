using Shlashurai.Skill;
using UnityEngine;
using Utilities.ReferenceHost;

namespace Shlashurai.UI
{
	public class SkillDisplay : MonoBehaviour
	{
		[SerializeField, Inject] private SkillCastManager m_skillCastManager = null;
		[SerializeField, Inject] private SkillHolder m_skillHolder = null;
		[SerializeField] private CastSliderDisplayModel m_castSliderDisplay = null;
		[SerializeField] private SkillSlotDisplay[] m_skillSlotDisplays = null;

		public void InitializeSkillDisplay()
		{
			var count = m_skillSlotDisplays.Length;
			for (var i = 0; i < count; i++)
			{
				var skillSlot = m_skillHolder.GetSkillSlot(i);
				m_skillSlotDisplays[i].Initialize(skillSlot);
			}
		}

		public void InitializeCastSlider()
		{
			m_castSliderDisplay.SkillCastManager = m_skillCastManager;
			m_castSliderDisplay.Initialize();
		}
	}
}