using Items;
using UnityEngine;

namespace Shlashurai.Items
{
	public class ItemImageComponent : IItemComponent
	{
		public Sprite ItemImage { get; private set; }

		public ItemImageComponent(Sprite sprite)
		{
			ItemImage = sprite;
		}
	}
}