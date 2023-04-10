using Shlashurai.Statistics;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentSpeedApplyLogic : StatisticApplyLogic
{
	[SerializeField] private NavMeshAgent m_navMeshAgent = null;

	public override void Apply()
	{
		m_navMeshAgent.speed = m_statisticToApply.Value;
	}

	[ContextMenu("GetMovementLogic")]
	private void GetMovementLogic()
	{
		var root = transform.root;
		m_navMeshAgent = root.GetComponent<NavMeshAgent>();
	}
}
