using Shlashurai.Items;
using System.Collections.Generic;
using Utilities.Consumable;

public class ConsumableItemComponent : IItemComponent, IConsumable
{
	public IEnumerable<IConsumableEffect> Effects { get; }

	public bool Instant { get; private set; }

	public ConsumableItemComponent(IEnumerable<IConsumableEffect> effects, bool instant)
	{
		Effects = effects;
		Instant = instant;
	}
}