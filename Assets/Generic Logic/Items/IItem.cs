using System.Collections.Generic;

namespace Shlashurai.Items
{
	public interface IItem
	{
		object ID { get; }
		bool IsActive { get; set; }
		bool IsStackable { get; }
		string DisplayName { get; }

		IEnumerable<IItemComponent> Components { get; }
	}
}