using Shlashurai.Player.Logic;
using Shlashurai.Statistics;
using UnityEngine;

public class MovementSpeedApplyLogic : StatisticApplyLogic
{
	[SerializeField] private PlayerMovementStateLogic[] m_playerMovementStateLogics = null;

	public override void Apply(Statistic statistic)
	{
		foreach (var player in m_playerMovementStateLogics)
			player.Speed = statistic.Value;
	}

	[ContextMenu("GetMovementLogic")]
	private void GetMovementLogic()
	{
		var root = transform.root;
		m_playerMovementStateLogics = root.GetComponentsInChildren<PlayerMovementStateLogic>();
	}
}
