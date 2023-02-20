using System.Collections.Generic;
using System.Linq;

namespace Shlashurai.Items
{
	public static class ItemHelperClass
	{
		public static T GetComponent<T>(this IItem item) => item.Components.OfType<T>().FirstOrDefault();

		public static IEnumerable<T> GetComponentsOfType<T>(this IItem item) => item.Components.OfType<T>();
	}
}