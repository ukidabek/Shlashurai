using Shlashurai.Input;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.States
{
	public class InventoryButtonSwitchStateCondition : StateLogic, ISwitchStateCondition
	{
		[SerializeField] private InputValues m_inputValues = null;
		public bool Condition
		{
			get
			{
				if(!m_isActivated) return false;

				if (m_toggle == m_inputValues.Inventory)
					m_toggle = true;
				
				return m_toggle && m_inputValues.Inventory;
			}
		}

		[SerializeField] private bool m_toggle = false;
		[SerializeField] private bool m_isActivated = false;

		public override void Activate()
		{
			base.Activate();
			m_isActivated = true;
			m_toggle = false;
		}

		public override void Deactivate()
		{
			base.Deactivate();
			m_toggle = m_isActivated = false;
		}
	}
}