using Items;
using UnityEngine.Events;
using Utilities.Interactions;

namespace Shlashurai.PickUp
{
	public class ItemPickUp : ItemBinder, IPickUpable
	{
		public UnityEvent OnPickUp = new UnityEvent();

		public object PickUp()
		{
			OnPickUp.Invoke();
			return Item;
		}
	}
}