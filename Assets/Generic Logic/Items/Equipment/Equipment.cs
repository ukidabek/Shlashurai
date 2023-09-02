using Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shlashurai.Items
{
	public class Equipment : IEquipment
	{
		public IEnumerable<IEquipmentSlot> Slots { get; }

		public Equipment(IEnumerable<IEquipmentSlot> slots)
		{
			Slots = slots;
		}

		public event Action<IItem> OnItemEquipped;
		public event Action<IItem> OnItemUnequipped;

		public void Equip(IItem item, bool overrideEquippedItems = false)
		{
			var selectedSlot = Slots.FirstOrDefault(slot => slot.CanEquip(item));
			if (selectedSlot == null) return;

			if (overrideEquippedItems == false && selectedSlot.Item != null)
				return;
			else if (selectedSlot.Item != null)
				UnEquip(selectedSlot.Item);

			selectedSlot.Equip(item);
			OnItemEquipped?.Invoke(item);
		}

		public void UnEquip(IItem item)
		{
			var selectedSlot = Slots.FirstOrDefault(slot => slot.Item == item);
			if (selectedSlot == null) return;
			selectedSlot.Unequip();
			OnItemUnequipped?.Invoke(item);
		}
	}
}