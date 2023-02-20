using System.Linq;
using UnityEngine;

namespace Utilities.Interactions
{
	[RequireComponent(typeof(Collider))]
	public class PickUpManager : MonoBehaviour
    {
        [SerializeField] private PickUpHandlerBase[] m_handlers;

		public void OnTriggerEnter(Collider other)
		{
			var pickUp = other.gameObject.GetComponent<IPickUpable>();
            var selectedHandlers = m_handlers.Where(handler => handler.CanHandle(pickUp));

			if (selectedHandlers.Any() == false) return;

			var pickUppedObject = pickUp.PickUp();
			
			if(pickUppedObject == null) return;

			foreach (var handler in selectedHandlers)
				handler.Handle(pickUppedObject);
		}
	}
}