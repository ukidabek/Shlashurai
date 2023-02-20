using Shlashurai.Skill;
using System;
using UnityEngine;

[Serializable]
public class CastSliderDisplayModel : SliderDisplayModel
{
	[SerializeField] protected SkillCastManagerReferenceHost m_skillCastManagerReferenceHost = null;

    private float m_percent = 0f;
	public override float Percent => m_percent;

    public override event Action OnValueChanged;

	protected override void PreProcess()
	{
		var castManager = m_skillCastManagerReferenceHost.Instance;
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
