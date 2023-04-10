using Shlashurai.Statistics;
using System.Linq;
using UnityEngine;

public class DamageDealingApplyLogic : StatisticApplyLogic
{
	[SerializeField] private Object m_damageDealingLogicObject = null;
	public IDamageDealingLogic m_damageDealingLogic = null;

	private void Awake()
	{
		if (m_damageDealingLogicObject == null) return;
		m_damageDealingLogic = m_damageDealingLogicObject as IDamageDealingLogic;
	}

	public override void Apply()
	{
		if (m_damageDealingLogic == null) return;
		m_damageDealingLogic.DamageAmount = m_statisticToApply.Value;
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
