using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class InventoryButtonSwitchStateCondition : StateLogic, ISwitchStateCondition
	{
		[SerializeField] private InputValues m_inputValues = null;
		public bool Condition
		{
			get
			{
				if(m_toggle == m_inputValues.Inventory)
					m_toggle = true;
				return m_toggle && m_inputValues.Inventory;
			}
		}

		private bool m_toggle = false;

		public override void Activate()
		{
			base.Activate();
			m_toggle = false;
		}
	}
}