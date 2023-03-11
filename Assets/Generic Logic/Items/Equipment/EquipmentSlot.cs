using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shlashurai.Items
{
	public class EquipmentSlot : MonoBehaviour, IEquipmentSlot
	{
		[SerializeField] private EquipmentDescriptor[] m_descriptors = null;
		[SerializeField] private Transform m_slotParent = null;
		public IEnumerable<IEquipmentDescriptor> Descriptors => m_descriptors;

		private IItem m_item = null;

		public event Action OnItemChanged;

		public IItem Item => m_item;

		public bool CanEquip(IItem item)
		{
			if(m_item == item) return true;

			var equipable = item.GetComponent<IEquipable>();
			if (equipable == null) return false;

			var matchingDescriptorCount = equipable.Descriptors.Intersect(Descriptors).Count();
			return matchingDescriptorCount == equipable.Descriptors.Count();
		}

		public void Equip(IItem item)
		{
			var equipment = item.GetComponent<IEquipable>();
			if (equipment == null) return;
			m_item = item;
			equipment.Equip(m_slotParent);
			OnItemChanged?.Invoke();
		}

		public IItem Unequip()
		{
			var equipable = m_item.GetComponent<IEquipable>();
			equipable.Unequip();
			OnItemChanged?.Invoke();
			return m_item;
		}
	}
}