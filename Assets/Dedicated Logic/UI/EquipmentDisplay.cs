using Shlashurai.Items;
using Shlashurai.Player;
using System.Linq;
using UnityEngine;

public class EquipmentDisplay : Display<EquipmentManagerReferenceHost, EquipmentManager>
{
	[SerializeField] private EquipmentSlotDisplay[] m_itemDisplays = null;

	protected override void Initialize(EquipmentManager instance)
	{
		var slots = instance.Slots;
		foreach (var slot in slots) 
		{
			var display = m_itemDisplays.FirstOrDefault(display => display.Descriptors.Intersect(slot.Descriptors).Any());
			display?.Initialize(slot);
		}
	}
}
