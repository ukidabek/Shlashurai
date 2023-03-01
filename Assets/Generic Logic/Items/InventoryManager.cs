using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Items
{
	public class InventoryManager : MonoBehaviour, IInventory
	{
		private Inventory m_inventory = null;

		[SerializeField] private int m_maxSlotCount = -1;
		[SerializeField] private ItemComponentHandler[] m_onAddComponentsHandlers = null;
		[SerializeField] private ItemComponentHandler[] m_onRemoveComponentsHandlers = null;

		public event Action OnInventoryChanged;

		private void Awake()
		{
			m_inventory = new Inventory(
				m_maxSlotCount, 
				m_onAddComponentsHandlers,
				m_onRemoveComponentsHandlers);

			m_inventory.OnInventoryChanged += InvokeOnChangeEvent;
		}

		private void InvokeOnChangeEvent() => OnInventoryChanged?.Invoke();

		private void OnDestroy()
		{
			m_inventory.OnInventoryChanged -= InvokeOnChangeEvent;
		}

		public IEnumerable<IItemSlot> Slots => m_inventory.Slots;

		public bool AddItem(IItem item) => m_inventory.AddItem(item);

		public void RemoveItem(IItem item) => m_inventory.RemoveItem(item);
	}
}