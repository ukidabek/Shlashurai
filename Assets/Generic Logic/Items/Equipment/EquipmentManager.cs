using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Items
{
	public class EquipmentManager : MonoBehaviour, IEquipment
	{
		[SerializeField] private EquipmentSlot[] m_slots = null;

		private Equipment m_equipment = null;

		public event Action<IItem> OnItemEquipped;
		public event Action<IItem> OnItemUnequipped;

		public IEnumerable<IEquipmentSlot> Slots => m_slots;

		private void Awake()
		{
			m_equipment = new Equipment(Slots);
			m_equipment.OnItemEquipped += InvokeOnItemEquipped;
			m_equipment.OnItemUnequipped += InvokeOnItemUnequipped;
		}

		private void OnDestroy()
		{
			m_equipment.OnItemEquipped -= InvokeOnItemEquipped;
			m_equipment.OnItemUnequipped -= InvokeOnItemUnequipped;
		}

		public void Equip(IItem equipment, bool overrideEquippedItems = false) => m_equipment.Equip(equipment, overrideEquippedItems);

		public void UnEquip(IItem equipment) => m_equipment.UnEquip(equipment);

		private void InvokeOnItemEquipped(IItem item) => OnItemEquipped?.Invoke(item);

		private void InvokeOnItemUnequipped(IItem item) => OnItemUnequipped?.Invoke(item);
	}
}