using UnityEngine;

namespace Utilities.Interactions
{
	public abstract class PickUpHandlerBase : MonoBehaviour
	{
		public abstract bool CanHandle(object pickUp);
		public abstract void Handle(object pickUp);
	}

	public abstract class PickUpHandlerBase<T> : PickUpHandlerBase where T : IPickUpable
	{
		public override bool CanHandle(object pickUp) => pickUp is T;
		protected T GetReference(object pickUp) => (T)pickUp;
	}
}