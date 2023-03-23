using Shlashurai.Items;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDescriptionComponentTemplate", menuName = "Items/Components/ItemDescriptionComponentTemplate")]
public class ItemDescriptionComponentTemplate : ItemComponentTemplate
{
	[SerializeField, TextArea(2, 2)] private string m_description = null;

	public override IItemComponent Create() => new ItemDescriptionComponent(m_description);
}
