using Shlashurai.Items;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlotDisplay : MonoBehaviour
{
	[SerializeField] private ItemDisplay m_itemDisplay;

	[SerializeField] private EquipmentDescriptor[] m_descriptors = null;

	private IEquipmentSlot m_slot = null;

	public IEnumerable<IEquipmentDescriptor> Descriptors => m_descriptors;

	public void Initialize(IEquipmentSlot slot)
	{
		if(m_slot != null)
			m_slot.OnItemChanged -= ManageDisplay;

		m_slot = slot;

		m_slot.OnItemChanged += ManageDisplay;
		if (m_slot.Item != null)
			ManageDisplay();
	}

	private void ManageDisplay()
	{
		m_itemDisplay.Initialize(m_slot.Item);
	}
}