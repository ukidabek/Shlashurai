namespace Shlashurai.Items
{
	public interface IItemComponentHandler
	{
		bool CanHandle(IItemComponent itemComponent);
		void Handle(IItemComponent itemComponent);
	}

}