using UnityEngine;

public class EndRoomReachedCondition : RemoteSwitchStateCondition
{
	private bool m_condition = false;
	public override bool Condition => m_condition;

	private void Awake() => m_condition = false;

	private void OnTriggerEnter(Collider other) => Trigger();

	[ContextMenu("Trigger")]
	private void Trigger() => m_condition = true;
}
