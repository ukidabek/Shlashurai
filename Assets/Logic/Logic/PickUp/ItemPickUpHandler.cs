using UnityEngine;
using Utilities.Interactions;
using Utilities.Consumable;
using Shlashurai.Items;

namespace Shlashurai.PickUp
{
	public class ItemPickUpHandler : PickUpHandlerBase
	{
		[SerializeField] private ConsumableHandler m_consumableHandler = null;

		public override bool CanHandle(object pickUp) => pickUp is ItemBinder binder && binder.Item != null && binder.Item is IConsumable;

		public override void Handle(object pickUp) => m_consumableHandler.Consume(pickUp as IConsumable);
	}
}
	