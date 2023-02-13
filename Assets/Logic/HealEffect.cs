using UnityEngine;
using Utilities.Consumable;

namespace Shlashurai.Consumable
{
	[CreateAssetMenu(menuName = "ConsumableEffect/HealEffect", fileName = "HealEffect")]
	public class HealEffect : ScriptableObject, IConsumableEffect
	{
		[SerializeField] private float m_healAmount = 10f;
		public float HealAmount => m_healAmount;
	}
}
