using Shlashurai.Items;
using System.Collections.Generic;
using Utilities.Consumable;

public class ConsumableItemComponent : IItemComponent, IConsumable
{
	public IEnumerable<IConsumableEffect> Effects { get; }

	public ConsumableItemComponent(IEnumerable<IConsumableEffect> effects)
	{
		Effects = effects;
	}
}