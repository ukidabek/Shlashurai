﻿using System;
using UnityEngine;

namespace Utilities.Events
{
	public abstract class Event<T> : ScriptableObject
    {
        [SerializeField] private bool m_debugLog = false;
        
        private event Action<T> m_delegate = null;

        public void Invoke(T context = default)
        {
            if (m_debugLog) 
                Debug.Log($"Event {name} was invoked witch context {context}");
            
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