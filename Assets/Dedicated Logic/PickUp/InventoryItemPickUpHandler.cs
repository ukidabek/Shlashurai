using Items;
using Items.Inventory;
using UnityEngine;
using Utilities.Interactions;

namespace Shlashurai.PickUp
{
	public class InventoryItemPickUpHandler : PickUpHandlerBase
	{
		[SerializeField] private InventoryManager inventory = null;
		public override bool CanHandle(object pickUp) => pickUp is ItemBinder binder && binder.Item != null;

		public override void Handle(object pickUp)
		{
			var item = pickUp as IItem;
			inventory.AddItem(item);
		}
	}
}
