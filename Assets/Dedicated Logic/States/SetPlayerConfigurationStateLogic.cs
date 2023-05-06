using Shlashurai.References;
using UnityEngine;
using Utilities.Configuration;

namespace Shlashurai.States
{
	public class SetPlayerConfigurationStateLogic : ReferenceHostUsingStateLogic<ConfigurationHandlerReferenceHost, ConfigurationHandler>
	{
		[SerializeField] private Config m_configuration = null;

		public override void Activate()
		{
			base.Activate();

			if (m_referenceHost == null) return;
			var configurationHandler = m_referenceHost.Instance;
			if (configurationHandler == null) return;
			configurationHandler.Configuration = m_configuration;
		}
	}
}