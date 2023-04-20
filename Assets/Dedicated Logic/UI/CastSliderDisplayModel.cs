using Shlashurai.Skill;
using System;

namespace Shlashurai.UI
{
	[Serializable]
	public class CastSliderDisplayModel : SliderDisplayModel
	{
		public SkillCastManager SkillCastManager { get; set; }

		private float m_percent = 0f;
		public override float Percent => m_percent;

		public override event Action OnValueChanged;

		protected override void PreProcess()
		{
			var castManager = SkillCastManager;
			castManager.OnSkillCastBegin += OnCastBegin;
			castManager.OnSkillCastProgress += OnSkillCastProgress;
			castManager.OnSkillCastEnd += OnCastEnd;

			m_display.gameObject.SetActive(false);
		}

		private void OnCastBegin(ISkill obj) => m_display.gameObject.SetActive(true);

		private void OnCastEnd(ISkill obj) => m_display.gameObject.SetActive(false);

		private void OnSkillCastProgress(float percent)
		{
			m_percent = percent;
			OnValueChanged?.Invoke();
		}
	}
}