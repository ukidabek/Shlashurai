using Items;
using UnityEngine;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "ItemPrefabComponentTemplate", menuName = "Items/Components/ItemPrefabComponentTemplate")]
	public class ItemPrefabComponentTemplate : ItemComponentTemplate
	{
		[SerializeField] private ItemBinder prefab;

		public override IItemComponent Create() => new ItemPrefabComponent(prefab);
	}
}