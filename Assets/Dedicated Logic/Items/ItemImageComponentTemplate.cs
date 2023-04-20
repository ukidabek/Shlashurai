﻿using UnityEngine;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "ItemImageComponentTemplate", menuName = "Items/Components/ItemImageComponentTemplate")]
	public class ItemImageComponentTemplate : ItemComponentTemplate
	{
		[SerializeField] private Sprite m_itemImage = null;

		public override IItemComponent Create() => new ItemImageComponent(m_itemImage);
	}
}