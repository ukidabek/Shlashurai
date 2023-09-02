﻿using Items;
using UnityEngine;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "ArmorComponentTemplate", menuName = "Items/Components/ArmorComponentTemplate")]
	public class ArmorComponentTemplate : ItemComponentTemplate
	{
		[SerializeField] private float m_armorValue = 0f;

		public override IItemComponent Create() => new ArmorItemComponent(m_armorValue);
	}
}