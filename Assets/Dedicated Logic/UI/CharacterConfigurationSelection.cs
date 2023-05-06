using UnityEngine;
using Utilities.Configuration;
using Utilities.Pool;

namespace Shlashurai.UI
{
	public class CharacterConfigurationSelection : MonoBehaviour
	{
		private ComponentPool<SelectCharacterConfigurationButton> m_characterConfigurationDisplayPool = null;

		[SerializeField] private Config[] m_configurations = null;
		[SerializeField] private SelectCharacterConfigurationButton m_characterConfigurationDisplayPrefab = null;
		[SerializeField] private Transform m_holder = null;

		private void Awake()
		{
			m_characterConfigurationDisplayPool = new ComponentPool<SelectCharacterConfigurationButton>(m_characterConfigurationDisplayPrefab, m_holder);

			var activeDisplays = m_characterConfigurationDisplayPool.ActiveObject;
			foreach (var item in activeDisplays)
				m_characterConfigurationDisplayPool.Return(item);

			foreach (var config in m_configurations) 
			{
				var display = m_characterConfigurationDisplayPool.Get();
				display.Initialize(config);
			}
		}
	}
}