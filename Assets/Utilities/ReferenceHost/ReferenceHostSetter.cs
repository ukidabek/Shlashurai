﻿using System.Collections;
using UnityEngine;

namespace Utilities.ReferenceHost
{
	public abstract class ReferenceHostSetter<ReferenceHostType, Type> : MonoBehaviour 
        where ReferenceHostType : ReferenceHost<Type> 
        where Type : Object
    {
        private enum SetReferenceMode { Awake, Start, LateStart, Manual }
        
        [SerializeField] private Type m_reference = default;
        [SerializeField] private ReferenceHostType m_host;
        [SerializeField] private SetReferenceMode m_setMode = SetReferenceMode.Awake;

		private void Awake()
		{
            if (m_setMode == SetReferenceMode.Manual) return;
			SetReference(SetReferenceMode.Awake);
		}

		private IEnumerator Start()
        {
			if (m_setMode == SetReferenceMode.Manual) yield break;
			SetReference(SetReferenceMode.Start);
            yield return null;
            SetReference(SetReferenceMode.LateStart);
        }

		private void SetReference(SetReferenceMode mode)
		{
			if (m_setMode == mode)
				SetReference();
		}

		public void SetReference() => m_host?.SetReference(m_reference);


		private void Reset()
        {
            m_reference = GetComponent<Type>();
        }
    }
}