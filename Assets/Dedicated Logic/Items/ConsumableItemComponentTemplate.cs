using Items;
using Shlashurai.Consumable;
using UnityEngine;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "ConsumableItemComponentTemplate", menuName = "Items/Components/ConsumableItemComponentTemplate")]
	public class ConsumableItemComponentTemplate : ItemComponentTemplate
	{
		[SerializeField] private bool m_instant = true;
		[SerializeField] private ConsumableEffect[] m_consumableEffects;

		public override IItemComponent Create() => new ConsumableItemComponent(m_consumableEffects, m_instant);
	}
}