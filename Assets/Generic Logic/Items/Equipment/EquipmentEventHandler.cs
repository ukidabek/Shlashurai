using UnityEngine;

namespace Shlashurai.Items
{
	public abstract class EquipmentEventHandler : MonoBehaviour
	{
		private IEquipment m_equipment = null;

		private void Awake()
		{
			m_equipment = GetComponent<IEquipment>();

			if (m_equipment == null) return;

			m_equipment.OnItemEquipped += OnItemEquipped;
			m_equipment.OnItemUnequipped += OnItemUnequipped;
		}

		private void OnDestroy()
		{
			if (m_equipment == null) return;

			m_equipment.OnItemEquipped -= OnItemEquipped;
			m_equipment.OnItemUnequipped -= OnItemUnequipped;
		}

		protected abstract void OnItemEquipped(IItem item);
		protected abstract void OnItemUnequipped(IItem item);
	}
}