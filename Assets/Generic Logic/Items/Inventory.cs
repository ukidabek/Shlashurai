using System;
using System.Collections.Generic;
using System.Linq;

namespace Shlashurai.Items
{
	public class Inventory : IInventory
	{
		private int m_maxSlotCount = -1;
		private List<ItemSlot> m_slots = new List<ItemSlot>();

		public IEnumerable<IItemSlot> Slots => m_slots;

		private IEnumerable<IItemComponentHandler> m_onAddComponentsHandlers = null;
		private IEnumerable<IItemComponentHandler> m_onRemoveComponentsHandlers = null;

		public event Action<IItemSlot> OnItemAdded;
		public event Action<IItemSlot> OnItemRemoved;

		public Inventory(int maxSlotCount, 
			IEnumerable<IItemComponentHandler> onAddComponentsHandlers,
			IEnumerable<IItemComponentHandler> onRemoveComponentsHandlers)
		{
			m_maxSlotCount = maxSlotCount;
			m_onAddComponentsHandlers = onAddComponentsHandlers;
			m_onRemoveComponentsHandlers = onRemoveComponentsHandlers;
		}

		public bool AddItem(IItem item)
		{
			if (m_maxSlotCount >= 0 && m_slots.Count == m_maxSlotCount)
				return false;

			ItemSlot slot = null;
			if (item.IsStackable)
			{
				slot = m_slots.FirstOrDefault(slot => slot.Item.ID == item.ID);
			}

			if (slot == null)
			{
				slot = new ItemSlot()
				{
					Item = item,
				};

				m_slots.Add(slot);
			}

			++slot.Count;

			foreach (var component in item.Components)
			{
				IItemComponentHandler componentHandler = GetHandler(m_onAddComponentsHandlers, component);
				componentHandler?.Handle(component);
			}

			OnItemAdded?.Invoke(slot);
			return true;
		}

		public void RemoveItem(IItem item)
		{
			var slot = m_slots.FirstOrDefault(itemSlot => itemSlot.Item == item);
			--slot.Count;
			if (slot.Count <= 0)
				m_slots.Remove(slot);

			foreach (var component in item.Components)
			{
				IItemComponentHandler componentHandler = GetHandler(m_onRemoveComponentsHandlers, component);
				componentHandler?.Handle(component);
			}

			OnItemRemoved?.Invoke(slot);
		}

		private IItemComponentHandler GetHandler(IEnumerable<IItemComponentHandler> handlers, IItemComponent component) 
			=> handlers.FirstOrDefault(handler => handler.CanHandle(component));
	}
}