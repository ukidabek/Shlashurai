using UnityEngine;

namespace Utilities.Interactions
{
	public abstract class PickUpHandlerBase : MonoBehaviour
	{
		public abstract bool CanHandle(IPickUpable pickUp);
		public abstract void Handle(IPickUpable pickUp);
	}

	public abstract class PickUpHandlerBase<T> : PickUpHandlerBase where T : IPickUpable
	{
		public override bool CanHandle(IPickUpable pickUp) => pickUp is T;
		protected T GetReference(IPickUpable pickUp) => (T)pickUp;
	}
}