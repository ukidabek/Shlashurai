using UnityEngine;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "ItemTemplate", menuName = "Items/Items/ItemTemplate")]
	public class ItemTemplate : ItemTemplateBase
	{
		[SerializeField] protected bool m_isStackable = false;
		public override IItem Create() => new Item(this, m_displayName, GetItemComponentInstances(), m_isStackable);
	}
}