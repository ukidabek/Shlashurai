using Items;
using UnityEngine;

namespace Shlashurai.UI
{
	public abstract class ItemComponentDescriptionDisplayHandler : MonoBehaviour
	{
		public abstract bool CanHandle(IItemComponent component);
		public abstract void Handle(IItemComponent component);

		public abstract void Clear();
	}

	public abstract class ItemComponentDescriptionDisplayHandler<T> : ItemComponentDescriptionDisplayHandler where T : IItemComponent
	{
		public override bool CanHandle(IItemComponent component) => component is T m_component;

		protected T Cast(IItemComponent component) => (T)component;
	}
}