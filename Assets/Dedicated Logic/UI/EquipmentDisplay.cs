using Shlashurai.Items;
using System.Linq;
using UnityEngine;
using Utilities.ReferenceHost;

namespace Shlashurai.UI
{
	public class EquipmentDisplay : MonoBehaviour, IInitializable
	{
		[SerializeField] private EquipmentSlotDisplay[] m_itemDisplays = null;
		[Inject] private IEquipment m_equipmentManager = null;

		public void Initialize() => Refresh();

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
}