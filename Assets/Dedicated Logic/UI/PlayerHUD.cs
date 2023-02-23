using Shlashurai.Player;
using System;
using System.Linq;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
	[SerializeField] private ResourceManagerReferenceHost m_resourceManagerReferenceHost = null;
    [SerializeField] private ResourceSliderDisplayModel[] m_resourceDisplays = null;
	[Space]
	[SerializeField] private SkillCastManagerReferenceHost m_skillCastManagerReferenceHost = null;
	[SerializeField] private CastSliderDisplayModel m_castSliderDisplay = null;
	[Space]
	[SerializeField] private SkillHolderReferenceHost m_skillHolderReferenceHost = null;
	[SerializeField] private SkillSlotDisplay[] m_skillSlotDisplays = null;

	private void Awake()
	{
		m_resourceManagerReferenceHost.OnReferenceChanged += InitializeResourceSliders;
		m_skillCastManagerReferenceHost.OnReferenceChanged += InitializeCastSlider;
		m_skillHolderReferenceHost.OnReferenceChanged += InitializeSkillDisplay;
	}

	private void OnDestroy()
	{
		m_resourceManagerReferenceHost.OnReferenceChanged -= InitializeResourceSliders;
		m_skillCastManagerReferenceHost.OnReferenceChanged -= InitializeCastSlider;
		m_skillHolderReferenceHost.OnReferenceChanged -= InitializeSkillDisplay;
	}

	private void InitializeCastSlider()
	{
		m_castSliderDisplay.SkillCastManager = m_skillCastManagerReferenceHost.Instance;
		m_castSliderDisplay.Initialize();
	}

	private void InitializeSkillDisplay()
	{
		var skillHolder = m_skillHolderReferenceHost.Instance;
		var count = m_skillSlotDisplays.Length;
		for (var i = 0; i < count; i++)
		{
			var skillSlot = skillHolder.GetSkillSlot(i);
			m_skillSlotDisplays[i].Initialize(skillSlot);
		}
	}

	private void InitializeResourceSliders()
	{
		var instance = m_resourceManagerReferenceHost.Instance;
		var list = Array.Empty<SliderDisplayModel>()
			.Concat(m_resourceDisplays.Select(model =>
			{
				model.ResourceManager = instance;
				return model;
			}));
		foreach (var item in list)
			item.Initialize();
	}
}