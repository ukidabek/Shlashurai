using System.Collections.Generic;

namespace Shlashurai.Items
{
	public class ItemDecorator : IItem
	{
		private IItem m_item = null;

		public ItemDecorator(IItem item)
		{
			m_item = item;
		}

		public virtual string DisplayName => m_item.DisplayName;

		public virtual IEnumerable<IItemComponent> Components => m_item.Components;

		public bool IsActive 
		{ 
			get => m_item.IsActive; 
			set => m_item.IsActive = value;
		}
	}

	public class Item : IItem
	{
		public string DisplayName { get; private set; }

		public IEnumerable<IItemComponent> Components {get; private set;}

		public bool IsActive { get; set; }

		public Item(string displayName, IEnumerable<IItemComponent> components)
		{
			DisplayName = displayName;
			Components = components;

			var componentsToInitialize = this.GetComponentsOfType<IInitializableItemComponent>();
			foreach (var component in componentsToInitialize)
				component.Initialize(this);
		}
	}
}