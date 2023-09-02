using Items;
using Items.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Shlashurai.UI
{
	public abstract class InventoryDisplayButtonHandler : MonoBehaviour
	{
		[SerializeField] protected Button m_button = null;

		protected IItem m_item = null;
		protected IInventory m_inventory = null;

		private void Awake()
		{
			m_button.onClick.AddListener(OnClick);
		}

		public virtual void Initialize(IInventory inventory)
		{
			m_inventory = inventory;
		}

		protected abstract void OnClick();

		public virtual void SetItem(IItem item)
		{
			m_item = item;
			m_button.gameObject.SetActive(m_item != null);
		}
	}
}