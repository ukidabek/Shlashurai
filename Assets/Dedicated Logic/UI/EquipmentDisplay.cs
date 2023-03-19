using Shlashurai.Items;
using System.Linq;
using UnityEngine;
using Utilities.ReferenceHost;

public class EquipmentDisplay : MonoBehaviour
{
	[SerializeField] private EquipmentSlotDisplay[] m_itemDisplays = null;
	[Inject] private IEquipment m_equipmentManager = null;

	public void Refresh()
	{
		var slots = m_equipmentManager.Slots;
		foreach (var slot in slots)
		{
			var display = m_itemDisplays.FirstOrDefault(display => display.Descriptors.Intersect(slot.Descriptors).Any());
			display?.Initialize(slot);
		}
	}
}
