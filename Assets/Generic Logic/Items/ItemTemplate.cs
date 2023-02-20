using System.Linq;
using UnityEngine;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "ItemTemplate", menuName = "Items/Items/ItemTemplate")]
	public class ItemTemplate : ItemTemplateBase
	{
		public override IItem Create() => new Item(m_displayName, GetItemComponentInstances());
	}
}