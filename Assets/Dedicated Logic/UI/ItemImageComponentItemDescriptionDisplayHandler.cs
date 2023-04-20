using Shlashurai.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Shlashurai.UI
{
	public class ItemImageComponentItemDescriptionDisplayHandler : ItemComponentDescriptionDisplayHandler<ItemImageComponent>
	{
		[SerializeField] private Image m_image = null;

		public override void Clear() => m_image.sprite = null;

		public override void Handle(IItemComponent component)
		{
			var imageComponent = Cast(component);
			m_image.sprite = imageComponent.ItemImage;
		}
	}
}