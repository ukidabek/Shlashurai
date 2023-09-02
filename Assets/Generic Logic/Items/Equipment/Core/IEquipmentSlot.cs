using Items;
using System;
using System.Collections.Generic;

namespace Shlashurai.Items
{
	public interface IEquipmentSlot
	{
		IItem Item { get; }
		IEnumerable<IEquipmentDescriptor> Descriptors { get; }
		bool CanEquip(IItem item);
		void Equip(IItem item);
		IItem Unequip();
		event Action OnItemChanged;
	}
}