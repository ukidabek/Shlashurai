using Shlashurai.Items;
using System.Collections.Generic;
using Utilities.Consumable;

public class ConsumableItem : Item, IConsumable
{
	public ConsumableItem(string displayName, IEnumerable<IItemComponent> components) : base(displayName, components)
	{
	}

	public IEnumerable<IConsumableEffect> Effects { get; private set; }
}
