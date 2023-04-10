using Shlashurai.Characters;
using Shlashurai.Statistics;
using UnityEngine;

public class ResourceFormStatisticApplyLogic : StatisticToResourceApplyLogic
{
	[SerializeField] private Statistic m_statistic = null;
	[SerializeField] private float m_resourceAmountPerStatisticPoint = 5;

	protected override Statistic[] Statistics => new[] { m_statistic };

	public override void Apply()
	{
		var resource = m_resourceManager.GetResource(m_resourceID);
		resource.MaxValue = m_resourceAmountPerStatisticPoint * m_statistic.Value;
	}
}
