using System.Collections.Generic;

namespace Utilities.Consumable
{
	public interface IConsumable
	{
		IEnumerable<IConsumableEffect> Effects { get; }
	}
}
