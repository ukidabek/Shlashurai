using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities.Consumable;

namespace Shlashurai.PickUp
{
	public class InstantConsumable : PickUpable, IConsumable
	{
		[SerializeField] private Object[] m_effectObjects = null;

		private IEnumerable<IConsumableEffect> m_effects = null;

		private void Awake()
		{
			m_effects = m_effectObjects.OfType<IConsumableEffect>();
		}

		public IEnumerable<IConsumableEffect> Effects => m_effects;
	}
}
