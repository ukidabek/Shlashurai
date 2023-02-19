﻿using Shlashurai.Skill;
using System;
using System.Linq;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private ResourceSliderDisplayModel[] m_resourceDisplays = null;
	[SerializeField] private CastSliderDisplayModel m_castSliderDisplay = null;
	[Space]
	[SerializeField] private SkillHolder m_skillHolder = null;
	[SerializeField] private SkillSlotDisplay[] m_skillSlotDisplays = null;

	private void Start()
	{
		var list = Array.Empty<SliderDisplayModel>()
			.Concat(m_resourceDisplays)
			.Concat(new[] { m_castSliderDisplay });

		foreach (var item in list)
			item.Initialize();

		var count = m_skillSlotDisplays.Length;
		for (var i = 0; i < count; i++)
		{
			var skillSlot = m_skillHolder.GetSkillSlot(i);
			m_skillSlotDisplays[i].Initialize(skillSlot);
		}
	}
}