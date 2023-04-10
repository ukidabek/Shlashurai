using Shlashurai.Statistics;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentSpeedApplyLogic : StatisticApplyLogic
{
	[SerializeField] private Statistic m_movementSpeedStatistic = null;
	[SerializeField] private NavMeshAgent m_navMeshAgent = null;
	protected override Statistic[] Statistics => new[] { m_movementSpeedStatistic };

	public override void Apply()
	{
		m_navMeshAgent.speed = m_movementSpeedStatistic.Value;
	}

	[ContextMenu("GetMovementLogic")]
	private void GetMovementLogic()
	{
		var root = transform.root;
		m_navMeshAgent = root.GetComponent<NavMeshAgent>();
	}
}
