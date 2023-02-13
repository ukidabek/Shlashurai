using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities.Consumable
{
	public class ConsumableHandler : MonoBehaviour
	{
		[SerializeField] private Object[] m_consumableEffectHandlrObjects = null;
		private IEnumerable<IConsumableEffectHandlr> m_consumableEffectHandlers = null;

		private void Awake()
		{
			m_consumableEffectHandlers = m_consumableEffectHandlrObjects.OfType<IConsumableEffectHandlr>();
		}

		public void Consume(IConsumable consumable)
		{
			var effects = consumable.Effects;
			foreach (var effect in effects)
			{
				var handler = m_consumableEffectHandlers.FirstOrDefault(handler => handler.CanHandle(effect));
				if(handler == null)
				{
					Debug.LogError($"Cant handle effect {effect.GetType().Name}");
					continue;
				}
				handler.Handle(effect);
			}
		}
	}
}
