namespace Shlashurai.Items
{
	public class ItemDescriptionComponent : IItemComponent
	{
		public string Description { get; private set; }

		public ItemDescriptionComponent(string description)
		{
			Description = description;
		}
	}
}