using Shlashurai.References;
using UnityEngine;
using Utilities.Configuration;
using Utilities.States;

namespace Shlashurai.States
{
	public class SetPlayerConfigurationStateLogic : StateLogic
	{
		[SerializeField] private Config m_configuration = null;
		[SerializeField] private ConfigurationHandlerReferenceHost m_consumableHandlerReferenceHost = null;
		[SerializeField] private DefaultEquipmentSetterReferenceHost m_equipmentSetterReferenceHost = null;

		public override void Activate()
		{
			base.Activate();

			if (m_consumableHandlerReferenceHost == null) return;
			var consumable = m_consumableHandlerReferenceHost.Instance;
			if (consumable == null) return;
			consumable.Configuration = m_configuration;

			if (m_equipmentSetterReferenceHost == null) return;
			var equipmentSetter = m_equipmentSetterReferenceHost.Instance;
			equipmentSetter.Set();
		}
	}
}