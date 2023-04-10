using Shlashurai.Statistics;
using UnityEngine;

public class ArmorApplyLogic : StatisticApplyLogic
{
	[SerializeField] private Statistic m_armorStatistic = null;
	[SerializeField] private HealthDamageHandler m_damageable = null;

	protected override Statistic[] Statistics => new[] { m_armorStatistic }; 

	public override void Apply() => m_damageable.Armor = m_armorStatistic.Value;

	[ContextMenu("GetDamageable")]
	private void GetMovementLogic()
	{
		var root = transform.root;
		m_damageable = root.GetComponent<HealthDamageHandler>();
	}
}