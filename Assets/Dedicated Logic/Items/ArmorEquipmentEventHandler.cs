using UnityEngine;

namespace Shlashurai.Items
{
	public class ArmorEquipmentEventHandler : EquipmentEventHandler
	{
		[SerializeField] private Damagable m_damagable = null;

		protected override void OnItemEquipped(IItem item)
		{
			if(item == null) return;
			var armor = item.GetComponent<IArmor>();
			if (armor == null) return;
			m_damagable.AddArmor(armor);
		}

		protected override void OnItemUnequipped(IItem item)
		{
			if (item == null) return;
			var armor = item.GetComponent<IArmor>();
			if (armor == null) return;
			m_damagable.RemoveArmor(armor);
		}
	}
}