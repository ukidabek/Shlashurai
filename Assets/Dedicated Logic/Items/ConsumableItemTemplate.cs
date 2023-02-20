using System.Collections.Generic;
using UnityEngine;
using Shlashurai.Consumable;
using Utilities.Consumable;

namespace Shlashurai.Items
{
	[CreateAssetMenu(fileName = "ItemTemplate", menuName = "Items/Items/ConsumableItemTemplate")]
	public class ConsumableItemTemplate : ItemTemplateBase
	{
		[SerializeField] private ConsumableEffect[] m_effects = null;

		private class ConsumableItem : Item, IConsumable
		{
			public ConsumableItem(string displayName, IEnumerable<IItemComponent> components, IEnumerable<IConsumableEffect> effects)
				: base(displayName, components)
			{
				Effects = effects;
			}

			public IEnumerable<IConsumableEffect> Effects { get; private set; }
		}

		public override IItem Create() => new ConsumableItem(m_displayName, GetItemComponentInstances(), m_effects);
	}
}