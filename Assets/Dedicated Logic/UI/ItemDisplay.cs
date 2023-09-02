using Items;
using System.Linq;
using UnityEngine;

namespace Shlashurai.UI
{
	public class ItemDisplay : MonoBehaviour
	{
		[SerializeField] private ItemComponentDescriptionDisplayHandler[] m_itemComponentDescriptionDisplayHandlers = null;

		private void Awake() => ClearHandlers();

		public void Initialize(IItem item)
		{
			if (item == null)
			{
				ClearHandlers();
				return;
			}

			foreach (var component in item.Components)
			{
				var handlers = m_itemComponentDescriptionDisplayHandlers.Where(handler => handler.CanHandle(component));
				foreach (var handler in handlers)
					handler.Handle(component);
			}
		}

		public void ClearHandlers()
		{
			foreach (var handler in m_itemComponentDescriptionDisplayHandlers)
				handler.Clear();
		}
	}
}