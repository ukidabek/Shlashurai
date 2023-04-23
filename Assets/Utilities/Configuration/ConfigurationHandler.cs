using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities.Configuration
{
	public class ConfigurationHandler : MonoBehaviour
	{
		[SerializeField] private Config m_configuration = null;
		public Config Configuration
		{
			get => m_configuration;
			set
			{
				if (m_configuration == value || 
					!ValidateConfiguration(value)) 
					return;
				Configure(m_configuration = value);
			}
		}

		[SerializeField] private Object[] m_settingsHandlers = null;
		private IEnumerable<ISettingHandler> m_settingHandlers = null;

		private void Awake()
		{
			m_settingHandlers = m_settingsHandlers.OfType<ISettingHandler>();
		}

		public void Configure(Config configuration)
		{
			var settings = configuration.Settings;
			foreach (var setting in settings)
			{
				var handlers = m_settingHandlers.Where(handler => handler.CanHandle(setting));
				foreach (var handler in handlers)
					handler.Handle(setting);
			}
		}

		protected virtual bool ValidateConfiguration(Config configuration) => true;

		[ContextMenu("Collect handlers")]
		public void CollectHandlers()
		{
			var scriptableObjectHandlers = m_settingsHandlers.Where(handler => handler.GetType().IsSubclassOf(typeof(ScriptableObject)));
			var componentHandlers = GetComponentsInChildren<ISettingHandler>().OfType<Object>();
			m_settingsHandlers = scriptableObjectHandlers.Concat(componentHandlers).ToArray(); ;
		}
	}
}