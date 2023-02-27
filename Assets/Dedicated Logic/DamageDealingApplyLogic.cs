using Shlashurai.Statistics;
using UnityEngine;

public class DamageDealingApplyLogic : StatisticApplyLogic
{
	[SerializeField] private Object m_damageDealingLogicObject = null;
	public IDamageDealingLogic m_damageDealingLogic = null;

	public override void Apply(Statistic statistic)
	{
		if (m_damageDealingLogicObject == null) return;

		if (m_damageDealingLogic == null)
			m_damageDealingLogic = m_damageDealingLogicObject as IDamageDealingLogic;

		if (m_damageDealingLogic == null) return;

		m_damageDealingLogic.DamageAmount = statistic.Value;
	}
}
