using Shlashurai.Statistics;
using System.Linq;
using UnityEngine;

public class DamageDealingApplyLogic : StatisticApplyLogic
{
	[SerializeField] private Statistic m_normalAttackStatistic = null;
	[SerializeField] private Statistic m_strengthAttackStatistic = null;
	[SerializeField] private float m_strengthToAttackConversionRatio = 0.25f;
	[SerializeField] protected Object m_damageDealingLogicObject = null;

	public IDamageDealingLogic m_damageDealingLogic = null;
	protected override Statistic[] Statistics => new[] 
	{ 
		m_normalAttackStatistic,
		m_strengthAttackStatistic
	};

	public override void Apply()
	{
		if (m_damageDealingLogic == null ||
			m_normalAttackStatistic == null ||
			m_strengthAttackStatistic == null)
			return;

		var normalAttack = m_normalAttackStatistic.Value;
		var formStrengthAttack = m_strengthAttackStatistic.Value * m_strengthToAttackConversionRatio;

		m_damageDealingLogic.DamageAmount = normalAttack + formStrengthAttack;
	}

	protected override void Awake()
	{
		base.Awake();
		if (m_damageDealingLogicObject == null) return;
		m_damageDealingLogic = m_damageDealingLogicObject as IDamageDealingLogic;
	}

	[ContextMenu("GetDamageDealingLogic")]
	public void GetDamageDealingLogic()
	{
		var root = transform.root.gameObject;
		var damagable = root.GetComponentsInChildren<IDamageDealingLogic>();
		if (damagable.Length > 1)
			Debug.LogWarning("There is more then one IDamageDealingLogic! Make sure that correct one is selected!");
		m_damageDealingLogicObject = damagable.FirstOrDefault() as Object;
	}
}
