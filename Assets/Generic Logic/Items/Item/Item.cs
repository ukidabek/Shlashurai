using System.Collections.Generic;

namespace Shlashurai.Items
{
	public class Item : IItem
	{
		public ItemTemplate Template { get; private set; }
		public object ID => Template;
		public string DisplayName { get; private set; }

		public IEnumerable<IItemComponent> Components {get; private set;}

		public bool IsActive { get; set; }

		public bool IsStackable { get; private set; }


		public Item(ItemTemplate template, string displayName, IEnumerable<IItemComponent> components, bool isStackable)
		{
			Template = template;
			DisplayName = displayName;
			Components = components;

			var componentsToInitialize = this.GetComponentsOfType<IInitializableItemComponent>();
			foreach (var component in componentsToInitialize)
				component.Initialize(this);
			IsStackable = isStackable;
		}
	}
}