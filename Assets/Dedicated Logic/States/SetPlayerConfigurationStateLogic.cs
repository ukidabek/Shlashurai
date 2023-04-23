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
			var consumable = m_referenceHost.Instance;
			if (consumable == null) return;
			consumable.Configuration = m_configuration;
		}
	}
}