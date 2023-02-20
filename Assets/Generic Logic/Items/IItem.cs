using System.Collections.Generic;

namespace Shlashurai.Items
{
	public interface IItem
	{
		public bool IsActive { get; set; }
		string DisplayName { get; }
		IEnumerable<IItemComponent> Components { get; }
	}
}