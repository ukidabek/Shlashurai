using Items;
using Money;

namespace Shlashurai.Items
{
	public class CurrencyItemComponent : IItemComponent
	{
		private float m_amount = 10f;
		private Currency m_currency = null;

		public CurrencyItemComponent(float amount, Currency currency)
		{
			m_amount = amount;
			m_currency = currency;
		}

		public void Apply() => m_currency.Amount += m_amount;
	}
}