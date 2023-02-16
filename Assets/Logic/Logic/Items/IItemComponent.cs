namespace Shlashurai.Items
{
	public interface IItemComponent
	{
		void Initialize(IItem item);
		void SetActive(bool status);
		void Destory();
	}
}