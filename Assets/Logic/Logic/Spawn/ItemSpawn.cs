using Shlashurai.Items;
using System.Linq;

namespace Shlashurai.Spawn
{
	public class ItemSpawn : SpawnBase<ItemPool, ItemTemplateBase, IItem, ItemPoolHandelr>
	{
		public IItem GetItemInstance(ItemTemplateBase item)
		{
			var poolHandler = m_poolHandlers.First(handler => handler.ObjectToSpawn == item);
			if (poolHandler == null)
				return null;

			return poolHandler.SpawnObject();
		}
	}
}