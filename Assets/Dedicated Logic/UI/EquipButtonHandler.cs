using Shlashurai.Items;
using Shlashurai.References;
using UnityEngine;

namespace Shlashurai.UI
{
	public class EquipButtonHandler : InventoryDisplayButtonHandler
	{
		[SerializeField] private EquipmentManagerReferenceHost m_equipmentManagerReferenceHost = null;

		public override void SetItem(IItem item)
		{
			base.SetItem(item);

			if (item == null) return;

			var isEquipable = item.HasComponent<IEquipable>();
			m_button.gameObject.SetActive(isEquipable);
		}

		protected override void OnClick()
		{
			var equipmentManager = m_equipmentManagerReferenceHost.Instance;
			equipmentManager.Equip(m_item, true);
		}
	}
}