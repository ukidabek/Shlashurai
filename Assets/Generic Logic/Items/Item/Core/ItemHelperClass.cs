using System.Collections.Generic;
using System.Linq;

namespace Items
{
	public static class ItemHelperClass
	{
		public static T GetComponent<T>(this IItem item) => item.Components.OfType<T>().FirstOrDefault();

		public static bool HasComponent<T>(this IItem item) => item.Components.OfType<T>().Any();

		public static IEnumerable<T> GetComponentsOfType<T>(this IItem item) => item.Components.OfType<T>();

		public static void SetItemStatus(this IItem item, bool status)
		{
			var manageableComponents = item.GetComponentsOfType<IManageableItemComponent>();
			foreach (var component in manageableComponents) 
				component.SetActive(status);
		}
	}
}