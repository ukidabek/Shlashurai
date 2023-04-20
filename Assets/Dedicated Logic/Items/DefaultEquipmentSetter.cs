using System.Linq;
using UnityEngine;

namespace Shlashurai.Items
{
	public class DefaultEquipmentSetter : MonoBehaviour
	{
		[SerializeField] private Object m_equipmentObject = null;
		private IEquipment m_equipment = null;

		[SerializeField] private ItemTemplate[] m_defaultItems = null;

		private void Awake()
		{
			m_equipment = m_equipmentObject as IEquipment;
		}

		private void Start()
		{
			if (m_equipment == null) return;

			foreach (var template in m_defaultItems)
			{
				var item = SpawnItem(template);
				m_equipment.Equip(item);
			}
		}

		public IItem SpawnItem(ItemTemplate template)
		{
			var item = template.Create();

			item.IsActive = true;
			var managableComponents = item.Components.OfType<IManageableItemComponent>();
			foreach (var component in managableComponents)
				component.SetActive(true);

			return item;
		}
	}
}