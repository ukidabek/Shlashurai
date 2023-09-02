namespace Items.Inventory
{
	public interface IItemSlot
	{
		IItem Item { get; }
		int Count { get; }
	}
}