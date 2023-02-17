using Shlashurai.Items;
using UnityEngine;

namespace Shlashurai.Spawn
{
	[CreateAssetMenu(menuName = "Spawn/Handler/ItemPoolHandelr", fileName = "ItemPoolHandelr")]
	public class ItemPoolHandelr : PoolHandler<ItemPool, ItemTemplateBase, IItem>
	{
		public override void Initialize(Transform parent)
		{
			base.Initialize(parent);
			m_pool = new ItemPool();
			m_pool.Initialize(m_objectToSpan, m_poolTransform);
		}
	}
}