using Shlashurai.Characters;
using UnityEngine;
using Utilities.Consumable;

namespace Shlashurai.Consumable
{
	public class ResourceConsumableEffectHandler : MonoBehaviour, IConsumableEffectHandlr
	{
		[SerializeField] private ResourceManager m_characterHealth = null;

		public bool CanHandle(IConsumableEffect effect) => effect is ResourceConsumableEffect;

		public void Handle(IConsumableEffect effect)
		{
			var resourceEffect = effect as ResourceConsumableEffect;
			var helth = m_characterHealth.GetResource(resourceEffect.ResourceID);
			helth.Value += resourceEffect.HealAmount;
		}
	}
}
