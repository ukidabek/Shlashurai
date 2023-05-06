using Shlashurai.Character;
using Shlashurai.References;
using UnityEngine;
using Utilities.Configuration;

namespace Shlashurai.States
{
	public class SetPlayerConfigurationStateLogic : ReferenceHostUsingStateLogic<ConfigurationHandlerReferenceHost, ConfigurationHandler>
	{
		[SerializeField] private CharacterSelectionManagerReferenceHost m_characterSelectionManager = null;

		public override void Activate()
		{
			base.Activate();

			if (m_referenceHost == null) return;
			var configurationHandler = m_referenceHost.Instance;

			if (m_characterSelectionManager == null) return;
			var config = m_characterSelectionManager.Instance.CurrentConfig;

			if (config == null) return;

			if (configurationHandler == null) return;
			configurationHandler.Configuration = config;
		}
	}
}