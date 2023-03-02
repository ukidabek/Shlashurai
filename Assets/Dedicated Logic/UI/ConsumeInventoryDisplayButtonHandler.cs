using Shlashurai.Items;
using Shlashurai.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities.Consumable;

public class ConsumeInventoryDisplayButtonHandler : InventoryDisplayButtonHandler
{
	[SerializeField] protected ConsumableHandlerReferenceHost m_consumableHandlerReferenceHost = null;

	private IEnumerable<IConsumable> m_consumables = null;

	public override void SetItem(IItem item)
	{
		base.SetItem(item);
		
		if (item == null) return;

		m_consumables = item.GetComponentsOfType<IConsumable>();
		m_button.gameObject.SetActive(m_consumables.Any());
	}

	protected override void OnClick()
	{
		var consumableHandler = m_consumableHandlerReferenceHost.Instance;

		foreach (var consumable in m_consumables)
			consumableHandler.Consume(consumable);

		m_inventory.RemoveItem(m_item);
	}
}