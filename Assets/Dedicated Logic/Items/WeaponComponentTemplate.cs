using Shlashurai.Items;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponComponentTemplate", menuName = "Items/Components/WeaponComponentTemplate")]
public class WeaponComponentTemplate : ItemComponentTemplate
{
	[SerializeField] private float m_minDamage = 0f;
	[SerializeField] private float m_maxDamage = 0f;

	public override IItemComponent Create() => new WeaponItemComponent(m_minDamage, m_maxDamage);
}