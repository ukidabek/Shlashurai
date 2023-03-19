using Shlashurai.Statistics;
using UnityEngine;

public class ArmorApplyLogic : StatisticApplyLogic
{
	[SerializeField] private HealthDamageHandler m_damagable = null;

	public override void Apply(Statistic statistic) => m_damagable.Armor = statistic.Value;

	[ContextMenu("GetDamagable")]
	private void GetMovementLogic()
	{
		var root = transform.root;
		m_damagable = root.GetComponent<HealthDamageHandler>();
	}
}