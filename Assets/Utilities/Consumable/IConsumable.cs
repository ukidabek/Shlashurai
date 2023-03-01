using System.Collections.Generic;

namespace Utilities.Consumable
{
	public interface IConsumable
	{
		bool Instant { get; }
		IEnumerable<IConsumableEffect> Effects { get; }
	}
}
