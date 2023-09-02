namespace Items.Inventory
{
	public class ItemSlot : IItemSlot
	{
		public IItem Item { get; set; }
		public int Count { get; set; }
	}
}