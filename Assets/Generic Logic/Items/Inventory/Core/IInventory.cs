using System;
using System.Collections.Generic;

namespace Items.Inventory
{
	public interface IInventory
	{
		IEnumerable<IItemSlot> Slots { get; }
		void AddItem(IItem item);
		void RemoveItem(IItem item);
		event Action<IItemSlot> OnItemAdded;
		event Action<IItemSlot> OnItemRemoved;
	}
}