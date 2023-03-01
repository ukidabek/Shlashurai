using Shlashurai.Items;
using TMPro;
using UnityEngine;

public class InventorySlotDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text m_itemName = null;

	internal void Initialize(IItemSlot slot)
	{
		m_itemName.text = slot.Item.DisplayName;
	}
}
