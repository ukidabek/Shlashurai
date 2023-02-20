using UnityEngine;
using Utilities.Interactions;
using Utilities.Consumable;
using Shlashurai.Items;

namespace Shlashurai.PickUp
{
	public class ItemPickUpHandler : PickUpHandlerBase
	{
		[SerializeField] private ConsumableHandler m_consumableHandler = null;

		public override bool CanHandle(object pickUp) => pickUp is ItemBinder binder &&
			binder.Item != null &&
			binder.Item.GetComponent<IConsumable>() != null;

		public override void Handle(object pickUp)
		{
			var item = pickUp as IItem;
			var consumable = item.GetComponent<IConsumable>();
			m_consumableHandler.Consume(consumable);
		}
	}
}
