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

		public event Action<IItemSlot> OnItemAdded;
		public event Action<IItemSlot> OnItemRemoved;

		private void Awake()
		{
			m_inventory = new Inventory(
				m_maxSlotCount, 
				m_onAddComponentsHandlers,
				m_onRemoveComponentsHandlers);

			m_inventory.OnItemAdded += OnItemAddedCallback;
			m_inventory.OnItemRemoved += OnItemRemovedCallback;
		}

		private void OnItemRemovedCallback(IItemSlot obj) => OnItemRemoved?.Invoke(obj);

		private void OnItemAddedCallback(IItemSlot obj) => OnItemAdded?.Invoke(obj);

		private void OnDestroy()
		{
			m_inventory.OnItemAdded -= OnItemAddedCallback;
			m_inventory.OnItemRemoved -= OnItemRemovedCallback;
		}

		public IEnumerable<IItemSlot> Slots => m_inventory.Slots;

		public void AddItem(IItem item) => m_inventory.AddItem(item);

		public void RemoveItem(IItem item) => m_inventory.RemoveItem(item);
	}
}