using Shlashurai.Items;
using TMPro;
using UnityEngine;

namespace Shlashurai.UI
{
	public class ItemDescriptionComponentItemDescriptionDisplayHandler : ItemComponentDescriptionDisplayHandler<ItemDescriptionComponent>
	{
		[SerializeField] private TMP_Text m_description = null;

		public override void Clear() => m_description.text = string.Empty;

		public override void Handle(IItemComponent component)
		{
			var descriptionComponent = Cast(component);
			m_description.text = descriptionComponent.Description;
		}
	}
}