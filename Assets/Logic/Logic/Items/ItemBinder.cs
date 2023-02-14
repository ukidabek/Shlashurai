using UnityEngine;

namespace Shlashurai.Items
{
	public abstract class ItemBinder : MonoBehaviour
    {
        [SerializeField] private Item m_item = null;
		public Item Item => m_item;

		internal void Bind(Item item)
		{
			m_item = item;
		}
	}
}