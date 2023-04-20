using UnityEngine;
using UnityEngine.AI;
using Utilities.States;

namespace Shlashurai.States
{
	public class StopNavMeshAgenStateLogic : StateLogic
	{
		[SerializeField] private NavMeshAgent m_agent = null;

		public override void Activate()
		{
			base.Activate();
			m_agent.isStopped = true;
		}

		public override void Deactivate()
		{
			base.Deactivate();
			m_agent.isStopped = false;
		}
	}
}