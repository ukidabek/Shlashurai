using Shlashurai.Items;
using UnityEngine;

namespace Shlashurai.Spawn
{
	[CreateAssetMenu(menuName = "Spawn/Spawn/ItemSpawn", fileName = "ItemSpawn")]
	public class ItemSpawn : SpawnBase<ItemPool, ItemTemplateBase, IItem, ItemPoolHandler>
	{
	}
}