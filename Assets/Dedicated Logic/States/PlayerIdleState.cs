using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class PlayerIdleState : StateLogic
	{
		[SerializeField] private Rigidbody m_rigidbody = null;

		public override void Activate()
		{
			base.Activate();
			m_rigidbody.isKinematic = true;
		}

		public override void Deactivate()
		{
			base.Deactivate();
			m_rigidbody.isKinematic = false;
		}
	}
}