using UnityEngine;
using UnityEngine.Events;
using Utilities.Interactions;

namespace Shlashurai.PickUp
{
	public class PickUpable : MonoBehaviour, IPickUpable
	{
		public UnityEvent OnPickUp = new UnityEvent();

		public void PickUp() => OnPickUp.Invoke();
	}
}
