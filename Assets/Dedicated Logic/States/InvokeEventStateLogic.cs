using UnityEngine;
using Utilities.Events;
using Utilities.States;

public abstract class InvokeEventStateLogic<EventType, Type> : StateLogic where EventType : Event<Type>
{
    [SerializeField] private EventType m_event = null;
    [SerializeField] private Type m_params = default;
	public override void Activate()
	{
		base.Activate();
        m_event.Invoke(m_params);
    }
}
