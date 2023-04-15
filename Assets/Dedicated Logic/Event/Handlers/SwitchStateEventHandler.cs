using UnityEngine;
using Utilities.Events;
using Utilities.States;

[RequireComponent(typeof(StateSetter))]
public class SwitchStateEventHandler : ObjectEventHandler
{
	[SerializeField] private StateSetter m_stateSetter = null;

	protected override void HandleEvent(object parameters = null) => m_stateSetter.SetState();

	private void Reset() => m_stateSetter = GetComponent<StateSetter>();
}
