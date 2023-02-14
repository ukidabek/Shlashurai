using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
	public class Item : ScriptableObject
	{
		[SerializeField] private ItemBinder m_itemPrefab = null;

		private void OnValidate()
		{
			m_itemPrefab?.Bind(this);
		}
	}
}