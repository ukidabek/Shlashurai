using System;
using System.Collections.Generic;

namespace Shlashurai.Items
{
	public interface IInventory
	{
		IEnumerable<IItemSlot> Slots { get; }
		bool AddItem(IItem item);
		void RemoveItem(IItem item);

		public event Action OnInventoryChanged;
	}
}