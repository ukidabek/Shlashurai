using Shlashurai.Items;
using Shlashurai.Player;
using System.Linq;
using UnityEngine;

public class EquipmentDisplay : Display<EquipmentManagerReferenceHost, EquipmentManager>
{
	[SerializeField] private EquipmentSlotDisplay[] m_itemDisplays = null;

	private EquipmentManager m_equipmentManager = null;

	protected override void Initialize(EquipmentManager instance) => m_equipmentManager = instance;

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
