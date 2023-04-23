namespace Utilities.Configuration
{
	public interface ISettingHandler
	{
		bool CanHandle(ISetting obj);
		void Handle(ISetting obj);
	}
}