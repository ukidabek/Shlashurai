using Shlashurai.Characters;
using Shlashurai.Statistics;
using UnityEngine;

public class ResourceRegenerationSpeedApplyLogic : StatisticToResourceApplyLogic
{
	[SerializeField] private Statistic m_statisticToCalculateRegenerationFrom = null;
	[SerializeField] private AnimationCurve m_statisticToRegenerationSpeedCurve = new AnimationCurve();
	[SerializeField] private ResourceOverTimeModifier m_resourceOverTimeModifier = null;
	protected override Statistic[] Statistics => new[] { m_statisticToCalculateRegenerationFrom };

	public override void Apply()
	{
		var statisticValue = m_statisticToCalculateRegenerationFrom.Value;
		var speed = m_statisticToRegenerationSpeedCurve.Evaluate(statisticValue);
		m_resourceOverTimeModifier.ModyficationSpeed = speed;
	}
}
