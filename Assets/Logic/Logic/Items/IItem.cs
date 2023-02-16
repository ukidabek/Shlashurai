using System.Collections.Generic;
using System.Linq;

namespace Shlashurai.Items
{
	public interface IItem
	{
		public bool IsActive { get; set; }
		string DisplayName { get; }
		IEnumerable<IItemComponent> Components { get; }
	}

	public static class ItemHelperClass
	{
		public static T GetComponet<T>(this IItem item)
		{
			var type = typeof(T);
			var components = item.Components;
			var component = components.FirstOrDefault(component => component.GetType() == typeof(T));
			return component != null ? (T)component : default;
		}
	}
}