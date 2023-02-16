using UnityEngine;

namespace Shlashurai.Consumable
{

	[CreateAssetMenu(menuName = "ConsumableEffect/HealEffect", fileName = "HealEffect")]
	public class HealEffect : ConsumableEffect
	{
		[SerializeField] private float m_healAmount = 10f;
		public float HealAmount => m_healAmount;
	}
}
