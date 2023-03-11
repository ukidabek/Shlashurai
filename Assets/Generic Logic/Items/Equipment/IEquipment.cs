using System;
using System.Collections.Generic;

namespace Shlashurai.Items
{
	public interface IEquipment
	{
		IEnumerable<IEquipmentSlot> Slots { get; }
		void Equip(IItem item, bool overrideEquippedItems = false);
		void UnEquip(IItem item);
		event Action<IItem> OnItemEquipped;
		event Action<IItem> OnItemUnequipped;
	}
}