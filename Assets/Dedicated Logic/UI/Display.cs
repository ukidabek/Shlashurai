using UnityEngine;
using Utilities.ReferenceHost;

public abstract class Display<T, T1> : MonoBehaviour where T : ReferenceHost<T1> where T1 : Object
{
	[SerializeField] protected T m_referenceHost = null;

	protected virtual void Awake()
	{
		m_referenceHost.OnReferenceChanged += OnReferenceChanged;
		if (m_referenceHost.Instance != null)
			Initialize(m_referenceHost.Instance);
	}

	protected virtual void OnReferenceChanged() => Initialize(m_referenceHost.Instance);
	protected virtual void OnDestroy()
	{
		m_referenceHost.OnReferenceChanged -= OnReferenceChanged;
	}

	protected abstract void Initialize(T1 instance);
}
