using Shlashurai.States;
using Shlashurai.Statistics;
using UnityEngine;

public class MovementSpeedApplyLogic : StatisticApplyLogic
{
	[SerializeField] private Statistic m_movementSpeedStatistic = null;
	[SerializeField] private PlayerMovementStateLogic m_playerMovementStateLogic = null;
	protected override Statistic[] Statistics => new[] { m_movementSpeedStatistic };

	public override void Apply()
	{
		if (m_playerMovementStateLogic == null) return;
		m_playerMovementStateLogic.Speed = m_movementSpeedStatistic.Value;
	}

	[ContextMenu("GetMovementLogic")]
	private void GetMovementLogic()
	{
		var root = transform.root;
		m_playerMovementStateLogic = root.GetComponentInChildren<PlayerMovementStateLogic>();
	}
}
