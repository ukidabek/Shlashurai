using Shlashurai.Items;

namespace Shlashurai.Spawn
{
	public class ItemPoolHandelr : PoolHandler<ItemPool, ItemTemplateBase, IItem>
	{
		public override void Initialize()
		{
			m_pool = new ItemPool();
			m_pool.Initialize(m_objectToSpan, m_poolTransform);
		}
	}
}