using UnityEngine;

namespace Utilities.Events
{
	public abstract class EventHandler<EventType, Type> : MonoBehaviour where EventType : Event<Type>
	{
		[SerializeField] private EventType m_event = null;

		private void OnEnable() => m_event?.Subscribe(HandleEvent);

		private void OnDisable() => m_event?.Unsubscribe(HandleEvent);

		private void OnDestroy() => m_event?.Unsubscribe(HandleEvent);

		protected abstract void HandleEvent(Type parameters = default);
	}
}