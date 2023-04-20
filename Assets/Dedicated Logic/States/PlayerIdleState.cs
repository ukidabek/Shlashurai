using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class PlayerIdleState : StateLogic
	{
		[SerializeField, Inject("Root")] private Transform m_root = null;
		[SerializeField, Inject] private Rigidbody m_rigidbody = null;

		public override void Activate()
		{
			base.Activate();
			m_rigidbody.isKinematic = true;
		}

		public override void Deactivate()
		{
			base.Deactivate();
			m_rigidbody.position = m_root.position;
			m_rigidbody.isKinematic = false;
		}
	}
}