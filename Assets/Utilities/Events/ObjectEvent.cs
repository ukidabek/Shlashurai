using UnityEngine;

namespace Utilities.Events
{
	[CreateAssetMenu(fileName = "ObjectEvent.asset", menuName = "Events/ObjectEvent")]
	public class ObjectEvent : Event<object>
	{
	}
}