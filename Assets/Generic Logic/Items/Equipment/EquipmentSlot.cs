using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shlashurai.Items
{
	public class EquipmentSlot : MonoBehaviour, IEquipmentSlot
	{
		[SerializeField] private Object[] m_descriptors = null;
		public IEnumerable<IEquipmentDescriptor> Descriptors => m_descriptors.OfType<IEquipmentDescriptor>();
		
		[SerializeField] private Transform m_slotParent = null;
		public Transform SlotParent
		{
			get => m_slotParent;
			set => m_slotParent = value;
		}

		public event Action OnItemChanged;

		private IItem m_item = null;
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