using UnityEngine;
using UnityEngine.AI;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class MoveToPlayerStateLogic : StateLogic, IOnUpdateLogic
	{
		[SerializeField] public TransformReferenceHost m_playerTransform = null;
		[SerializeField] public NavMeshAgent m_navMeshAgent = null;


		public void OnUpdate(float deltaTime, float timeScale)
		{
			var player = m_playerTransform.Instance;
			m_navMeshAgent.destination = player.position;
		}
	}
}