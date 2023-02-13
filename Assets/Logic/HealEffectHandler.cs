using Shlashurai.Characters;
using UnityEngine;
using Utilities.Consumable;
using Utilities.General;

namespace Shlashurai.Consumable
{
	public class HealEffectHandler : MonoBehaviour, IConsumableEffectHandlr
	{
		[SerializeField] private ResourceID m_heltResourceId = null;
		[SerializeField] private ResourceManager m_characterHealth = null;

		public bool CanHandle(IConsumableEffect effect) => effect is HealEffect;

		public void Handle(IConsumableEffect effect)
		{
			var healEffect = effect as HealEffect;
			var helth = m_characterHealth.GetResource(m_heltResourceId);

			helth.CurrentValue += healEffect.HealAmount;
		}
	}
}
