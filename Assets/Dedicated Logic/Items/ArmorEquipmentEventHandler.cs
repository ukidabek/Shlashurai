using Items;
using UnityEngine;

namespace Shlashurai.Items
{
	public class ArmorEquipmentEventHandler : EquipmentEventHandler
	{
		[SerializeField] private HealthDamageHandler m_healthDamageHandler = null;

		protected override void OnItemEquipped(IItem item)
		{
			if(item == null) return;
			var armor = item.GetComponent<IArmor>();
			if (armor == null) return;
			m_healthDamageHandler.AddArmor(armor);
		}

		protected override void OnItemUnequipped(IItem item)
		{
			if (item == null) return;
			var armor = item.GetComponent<IArmor>();
			if (armor == null) return;
			m_healthDamageHandler.RemoveArmor(armor);
		}
	}
}