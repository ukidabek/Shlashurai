using UnityEngine;
using Utilities.Events;
using Utilities.States;

namespace Shlashurai.Character
{
	public class ObjectEventSwitchStateCondition : StateLogic, ISwitchStateCondition
	{
		[SerializeField] private ObjectEvent m_onConfigSelected = null; 

		[SerializeField] private bool m_condition = false;
		public bool Condition => m_condition;

		private void Awake() => m_onConfigSelected?.Subscribe(OnConfigSelected);
		private void OnDestroy() => m_onConfigSelected?.Unsubscribe(OnConfigSelected);

		private void OnConfigSelected(object obj) => m_condition = true;

		public override void Activate()
		{
			base.Activate();
			m_condition = false;
		}
	}
}