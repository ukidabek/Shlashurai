using UnityEngine;

namespace Utilities.Events
{
	[CreateAssetMenu(fileName = "IntEvent.asset", menuName = "Events/IntEvent")]
	public class IntEvent : Event<int>
	{
	}
}