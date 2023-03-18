using Shlashurai.Items;
using Shlashurai.Player;
using UnityEngine;
using Utilities.Pool;

public class InventoryDisplay : Display<InventoryManagerReferenceHost, InventoryManager>
{
	[SerializeField] private InventorySlotDisplay m_inventorySlotPrefab = null;
	[SerializeField] private Transform m_slotDisplayParent = null;
	[SerializeField] private ItemDisplay m_itemDescriptionDisplay = null;
	[SerializeField] private InventoryDisplayButtonHandler[] m_buttonHandlers = null;

	private ComponentPool<InventorySlotDisplay> m_inventorySlotDisplayPool = null;
	private IInventory m_inventory = null;
	private IItem m_item = null;

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (m_inventory == null) return;
		m_inventory.OnItemAdded -= OnItemAddedCallback;
		m_inventory.OnItemRemoved -= OnItemRemovedCallback;
	}

	private void OnItemAddedCallback(IItemSlot obj) => OnInventoryChanged();

	private void OnItemRemovedCallback(IItemSlot obj)
	{
		OnInventoryChanged();
		if(obj.Item == m_item && obj.Count == 0)
			m_itemDescriptionDisplay.ClearHandlers();
	}

	private void OnInventoryChanged()
	{
		foreach (var item in m_inventorySlotDisplayPool.ActiveObject)
		{
			item.OnItemSelected -= OnItemSelected;
			m_inventorySlotDisplayPool.Return(item);
		}

		foreach (var item in m_inventory.Slots)
		{
			var display = m_inventorySlotDisplayPool.Get();
			display.Initialize(item);
			display.OnItemSelected += OnItemSelected;
		}
	}

	private void OnItemSelected(IItem item)
	{
		m_item = item;

		foreach (var buttonHandler in m_buttonHandlers)
			buttonHandler.SetItem(item);
		m_itemDescriptionDisplay.Initialize(item);
	}

	protected override void Initialize(InventoryManager instance)
	{
		if (m_inventorySlotDisplayPool == null)
			m_inventorySlotDisplayPool = new ComponentPool<InventorySlotDisplay>(m_inventorySlotPrefab, m_slotDisplayParent, 20);

		m_inventory = instance;
		m_inventory.OnItemAdded += OnItemAddedCallback;
		m_inventory.OnItemRemoved += OnItemRemovedCallback;

		foreach (var buttonHandler in m_buttonHandlers)
			buttonHandler.Initialize(m_inventory);

		OnInventoryChanged();
	}
}