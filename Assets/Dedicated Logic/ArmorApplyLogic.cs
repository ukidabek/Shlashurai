using Shlashurai.Statistics;
using UnityEngine;

public class ArmorApplyLogic : StatisticApplyLogic
{
	[SerializeField] private HealthDamageHandler m_damageable = null;

	public override void Apply() => m_damageable.Armor = m_statisticToApply.Value;

	[ContextMenu("GetDamageable")]
	private void GetMovementLogic()
	{
		var root = transform.root;
		m_damageable = root.GetComponent<HealthDamageHandler>();
	}
}