using Shlashurai.Items;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemPrefabComponentTemplate", menuName = "Items/Components/ItemPrefabComponentTemplate")]
public class ItemPrefabComponentTemplate : ItemComponentTemplate
{
	[SerializeField] private ItemBinder prefab;

	public override IItemComponent Create() => new ItemPrefabComponent(prefab);
}