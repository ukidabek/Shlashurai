using Shlashurai.Items;
using Shlashurai.References;

namespace Shlashurai.States
{
	public class SetDefaultEquipmentSetter : ReferenceHostUsingStateLogic<DefaultEquipmentSetterReferenceHost, DefaultEquipmentSetter>
	{
		public override void Activate()
		{
			base.Activate();

			if (m_referenceHost == null) return;
			var equipmentSetter = m_referenceHost.Instance;
			equipmentSetter.Set();
		}
	}
}