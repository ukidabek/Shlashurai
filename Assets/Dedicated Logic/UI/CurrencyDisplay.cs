using Money;
using TMPro;
using UnityEngine;

namespace Shlashurai.UI
{
	public class CurrencyDisplay : MonoBehaviour
	{
		[SerializeField] private Currency m_currency = null;
		[SerializeField] private TMP_Text m_name = null;
		[SerializeField] private TMP_Text m_amount = null;

		private void Awake()
		{
			m_currency.OnCurencyChanged += OnCurencyChanged;
			m_name.text = m_currency.name;
			OnCurencyChanged();
		}

		private void OnDestroy()
		{
			m_currency.OnCurencyChanged -= OnCurencyChanged;
		}

		private void OnCurencyChanged()
		{
			m_amount.text = m_currency.Amount.ToString("0");
		}
	}
}