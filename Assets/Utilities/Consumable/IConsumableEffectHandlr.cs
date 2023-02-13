namespace Utilities.Consumable
{
	public interface IConsumableEffectHandlr
	{
		bool CanHandle(IConsumableEffect effect);
		void Handle(IConsumableEffect effect);
	}
}
