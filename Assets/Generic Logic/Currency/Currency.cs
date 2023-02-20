using System;
using System.Collections.Generic;
using UnityEngine;

namespace Money
{
	[CreateAssetMenu(fileName = "Currency", menuName = "Currency/Currency")]
	public class Currency : ScriptableObject
	{
		public event Action OnCurencyChanged = null;
		[SerializeField] private float m_amount;
		public float Amount
		{
			get => m_amount;
			set 
			{
				if(m_amount != value) 
				{
					m_amount = value;
					OnCurencyChanged?.Invoke();
				}
			}
		}

		[SerializeField] private CurrencyComponent[] m_components = null;
		public IEnumerable<CurrencyComponent> Components { get { return m_components; } }
	}
}
