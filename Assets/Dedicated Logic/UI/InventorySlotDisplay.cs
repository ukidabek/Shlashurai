using Items;
using Items.Inventory;
using Shlashurai.Items;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shlashurai.UI
{
	public class InventorySlotDisplay : MonoBehaviour
	{
		[SerializeField] private Image m_itemImage = null;
		[SerializeField] private TMP_Text m_itemName = null;
		[SerializeField] private Button m_button = null;
		[SerializeField] private TMP_Text m_countDisplay = null;

		private IItem m_item = null;
		public event Action<IItem> OnItemSelected = null;

		public void Initialize(IItemSlot slot)
		{
			m_item = slot.Item;
			m_button.onClick.RemoveAllListeners();
			m_button.onClick.AddListener(Select);
			m_itemName.text = slot.Item.DisplayName;

			if (m_item.IsStackable)
			{
				m_countDisplay.gameObject.SetActive(true);
				m_countDisplay.text = $"{slot.Count}";
			}
			else
				m_countDisplay.gameObject.SetActive(false);

			var imageComponent = m_item.GetComponent<ItemImageComponent>();
			if (imageComponent != null)
				m_itemImage.sprite = imageComponent.ItemImage;
		}

		private void Select() => OnItemSelected?.Invoke(m_item);
	}
}