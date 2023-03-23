using Shlashurai.Items;
using UnityEngine;

public class ItemImageComponent : IItemComponent
{
	public Sprite ItemImage { get; private set; }

	public ItemImageComponent(Sprite sprite)
	{
		ItemImage = sprite;
	}
}
