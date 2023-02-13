using System;
using UnityEngine;

namespace Shlashurai.Characters
{
	[Serializable]
	public class Resource
	{
		[SerializeField] private ResourceID m_id;
		public ResourceID ID => m_id;

		[SerializeField] private float m_maxValue = 100;
		public float MaxValue
		{
			get { return m_maxValue; }
			set { m_maxValue = value; }
		}

		[SerializeField] private float m_currentHealth = 0;
		public float CurrentValue
		{
			get { return m_currentHealth; }
			set 
			{
				var oldValue = m_currentHealth;
				m_currentHealth = Mathf.Clamp(value, 0f, m_maxValue);
				if (m_currentHealth != oldValue)
					OnValueChanged?.Invoke();
			}
		}

		public float Percent => Mathf.Clamp01(m_currentHealth / m_maxValue);

		public event Action OnValueChanged = null;

		public void Reset()
		{
			CurrentValue = m_maxValue;
			OnValueChanged?.Invoke();
		}

	}
}