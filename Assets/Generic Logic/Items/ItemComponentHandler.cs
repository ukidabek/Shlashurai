using UnityEngine;

namespace Shlashurai.Items
{
	public abstract class ItemComponentHandler : MonoBehaviour, IItemComponentHandler
	{
		public abstract bool CanHandle(IItemComponent itemComponent);
		public abstract void Handle(IItemComponent itemComponent);
	}

	public abstract class ItemComponentHandler<T> : ItemComponentHandler where T : IItemComponent
	{
		public override bool CanHandle(IItemComponent itemComponent) => itemComponent is T;
	}
}