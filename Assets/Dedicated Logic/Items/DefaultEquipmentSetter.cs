using Shlashurai.Items;
using System.Linq;
using UnityEngine;

public class DefaultEquipmentSetter : MonoBehaviour
{
	private IEquipment m_equipment = null;

	[SerializeField] private ItemTemplate[] m_defaultItems = null;

	private void Start()
	{
		m_equipment = GetComponent<IEquipment>();
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
