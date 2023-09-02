using Items;

namespace Shlashurai.Items
{
	public class ArmorItemComponent : IItemComponent, IArmor
	{
		public float Value { get; private set; }

		public ArmorItemComponent(float value)
		{
			Value = value;
		}
	}
}