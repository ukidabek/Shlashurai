using Items;
using UnityEngine;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "EquipableItemPrefabComponentTemplate", menuName = "Items/Components/EquipableItemPrefabComponentTemplate")]
	public class EquipableItemPrefabComponentTemplate : ItemComponentTemplate
	{
		[SerializeField] private ItemBinder m_prefab = null;
		[SerializeField] private EquipmentDescriptor[] m_equipmentDescriptor = null;
		[SerializeField] private Object[] m_modifiers = null;
		[SerializeField] private Vector3 m_localPosition = Vector3.zero;
		[SerializeField] private Vector3 m_localRotation = Vector3.zero;

		public override IItemComponent Create() => new EquipableItemPrefabComponent(
			m_prefab,
			m_equipmentDescriptor,
			m_modifiers,
			m_localPosition,
			m_localRotation);
	}
}