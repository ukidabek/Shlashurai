using UnityEngine;
using Utilities.Interactions;
using Utilities.Consumable;

namespace Shlashurai.PickUp
{
	public class InstantConsumableHandler : PickUpHandlerBase<InstantConsumable>
	{
		[SerializeField] private ConsumableHandler m_consumableHandler = null;

		public override void Handle(IPickUpable pickUp)
		{
			var consumable = GetReference(pickUp);
			if (consumable == null)
				return;
			m_consumableHandler.Consume(consumable);
		}
	}
}
	