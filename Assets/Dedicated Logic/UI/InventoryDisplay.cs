using Shlashurai.Items;
using UnityEngine;
using Utilities.Pool;

public class InventoryDisplay : MonoBehaviour
{
	[SerializeField] private InventorySlotDisplay m_inventorySlotPrefab = null;
	[SerializeField] private Transform m_slotDisplayParent = null;
	private ComponentPool<InventorySlotDisplay> m_inventorySlotDisplayPool = null;
	private IInventory m_inventory = null;

	private void Awake()
	{
	}

	public void Initialize(IInventory inventory)
	{
		if(m_inventorySlotDisplayPool == null)
			m_inventorySlotDisplayPool = new ComponentPool<InventorySlotDisplay>(m_inventorySlotPrefab, m_slotDisplayParent, 20);

		m_inventory = inventory;
		m_inventory.OnInventoryChanged += OnInventoryChanged;
		OnInventoryChanged();
	}

	private void OnInventoryChanged()
	{
		foreach (var item in m_inventorySlotDisplayPool.ActiveObject)
			m_inventorySlotDisplayPool.Return(item);

		foreach (var item in m_inventory.Slots)
		{
			var display = m_inventorySlotDisplayPool.Get();
			display.Initialize(item);
		}
	}
}
