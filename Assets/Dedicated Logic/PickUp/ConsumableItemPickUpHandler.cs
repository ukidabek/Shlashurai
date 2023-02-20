using UnityEngine;
using Utilities.Consumable;

namespace Shlashurai.PickUp
{
	public class ConsumableItemPickUpHandler : ItemPickUpHandler<IConsumable>
	{
		[SerializeField] private ConsumableHandler m_consumableHandler = null;

		public override void Handle(object pickUp) => m_consumableHandler.Consume(m_itemComponent);
	}
}
