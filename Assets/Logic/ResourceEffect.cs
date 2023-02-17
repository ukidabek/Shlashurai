using Shlashurai.Characters;
using UnityEngine;

namespace Shlashurai.Consumable
{
	[CreateAssetMenu(menuName = "ConsumableEffect/HealEffect", fileName = "HealEffect")]
	public class ResourceEffect : ConsumableEffect
	{
		[SerializeField] private ResourceID m_resourceID = null;
		public ResourceID ResourceID => m_resourceID;

		[SerializeField] private float m_healAmount = 10f;
		public float HealAmount => m_healAmount;
	}
}
