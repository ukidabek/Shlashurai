namespace Shlashurai.Items
{
	public interface IItemSlot
	{
		IItem Item { get; }
		int Count { get; }
	}
}