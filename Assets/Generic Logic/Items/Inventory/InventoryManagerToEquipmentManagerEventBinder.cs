using Shlashurai.Items;
using UnityEngine;

namespace Items.Inventory
{
	public class InventoryManagerToEquipmentManagerEventBinder : MonoBehaviour
	{
		[SerializeField] private InventoryManager m_inventoryManager = null;
		[SerializeField] private EquipmentManager m_equipmentManager = null;

		private void OnEnable()
		{
			m_equipmentManager.OnItemEquipped += m_inventoryManager.RemoveItem;
			m_equipmentManager.OnItemUnequipped += m_inventoryManager.AddItem;
		}
	}
}