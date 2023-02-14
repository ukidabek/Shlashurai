using System.Linq;
using UnityEngine;

namespace Utilities.Interactions
{
	[RequireComponent(typeof(Collider))]
	public class PickUpManager : MonoBehaviour
    {
        [SerializeField] private PickUpHandlerBase[] handlers;

		public void OnTriggerEnter(Collider other)
		{
			var pickUp = other.gameObject.GetComponent<IPickUpable>();
            var handler = handlers.FirstOrDefault(handler => handler.CanHandle(pickUp));
            
			if (handler == null)
                return;

			var pickUpedObject = pickUp.PickUp();
			handler.Handle(pickUpedObject);
		}
	}
}