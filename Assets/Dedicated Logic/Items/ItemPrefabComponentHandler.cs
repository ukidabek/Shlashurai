using Items;
using Items.Inventory;
using UnityEngine;

namespace Shlashurai.Items
{
	public class ItemPrefabComponentHandler : ItemComponentHandler<ItemPrefabComponent>
	{
		public override void Handle(IItemComponent itemComponent)
		{
			var itemPrefabComponent = (ItemPrefabComponent)itemComponent;
			itemPrefabComponent.SetActive(false);
			itemPrefabComponent.SetParent(transform, false);
			itemPrefabComponent.Instance.transform.localPosition = Vector3.zero;
		}
	}
}