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

		[SerializeField] private float m_value = 0;
		public float Value
		{
			get { return m_value; }
			set 
			{
				var oldValue = m_value;
				m_value = Mathf.Clamp(value, 0f, m_maxValue);
				if (m_value != oldValue)
					OnValueChanged?.Invoke();
			}
		}

		public float Percent => Mathf.Clamp01(m_value / m_maxValue);

		public event Action OnValueChanged = null;

		public void Reset()
		{
			Value = m_maxValue;
			OnValueChanged?.Invoke();
		}
	}
}