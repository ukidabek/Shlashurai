using System;
using UnityEngine;

namespace Logic.Events
{
    public abstract class EventBase<T> : ScriptableObject
    {
        [SerializeField] private bool m_debugLog = false;
        
        private event Action<T> m_delegate = null;

        public void Invoke(T context)
        {
            if (m_debugLog) 
                Debug.Log($"Event {name} was invoked witch context {context.ToString()}");
            
            m_delegate?.Invoke(context);
        }

        public void Subscribe(Action<T> action)
        {
            if (m_debugLog) 
                Debug.Log($"Object {action.Target} is subscribing to event {name}");

            m_delegate -= action;
            m_delegate += action;
        }

        public void Unsubscribe(Action<T> action)
        {
            if (m_debugLog) 
                Debug.Log($"Object {action.Target} is unsubscribe form event {name}");
            
            m_delegate -= action;
        }
    }
}