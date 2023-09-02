using Items;
using Money;
using UnityEngine;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "CurrencyItemComponentTemplate", menuName = "Items/Components/CurrencyItemComponentTemplate")]
	public class CurrencyItemComponentTemplate : ItemComponentTemplate
	{
		[SerializeField] private float m_amount = 10f;
		[SerializeField] private Currency m_currency = null;

		public override IItemComponent Create() => new CurrencyItemComponent(m_amount, m_currency);
	}
}