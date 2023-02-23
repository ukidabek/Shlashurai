using UnityEngine;
using Utilities.States;

public class StateDictionaryHandlingStateLogic : StateLogic
{
	[SerializeField] private StateDictionaryReferenceHost m_stateDictionaryReferenceHost = null;
	[SerializeField] private StateID m_stateID = null;

	public override void Activate()
	{
		base.Activate();
		m_stateDictionaryReferenceHost.Instance.SetState(m_stateID);
	}
}
