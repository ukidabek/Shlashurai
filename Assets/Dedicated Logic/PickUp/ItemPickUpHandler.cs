using Utilities.Interactions;
using Shlashurai.Items;

namespace Shlashurai.PickUp
{
	public abstract class ItemPickUpHandler<T> : PickUpHandlerBase 
	{
		protected T m_itemComponent = default;

		public override bool CanHandle(object pickUp)
		{
			if(pickUp is ItemBinder binder && binder.Item != null)
			{
				m_itemComponent = binder.Item.GetComponent<T>();
				return m_itemComponent != null;
			}

			return false;
		}

	}
}
