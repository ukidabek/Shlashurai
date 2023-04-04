using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

public abstract class RemoteSwitchStateCondition : MonoBehaviour, ISwitchStateCondition, IInitializable
{
	[Inject, SerializeField] protected SwitchStateStateLogic m_switchStateLogic = null;

	public abstract bool Condition { get; }

	public virtual void Initialize() => m_switchStateLogic.AddCondition(this);

	private void OnDestroy() => m_switchStateLogic.RemoveCondition(this);
}
