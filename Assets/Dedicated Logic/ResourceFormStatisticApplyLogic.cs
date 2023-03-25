using Shlashurai.Characters;
using Shlashurai.Statistics;
using UnityEngine;

public class ResourceFormStatisticApplyLogic : StatisticApplyLogic
{
	[SerializeField] private ResourceManager m_resourceManager = null;
	[SerializeField] private ResourceID m_resourceID = null;

	[SerializeField] private float m_resourceAmountPerStatistionPoint = 5; 

	public override void Apply(Statistic statistic)
	{
		var resource = m_resourceManager.GetResource(m_resourceID);
		resource.MaxValue = m_resourceAmountPerStatistionPoint * statistic.Value;
	}

	[ContextMenu("GetResourceManager")]
	private void GetMovementLogic()
	{
		var root = transform.root;
		m_resourceManager = root.GetComponent<ResourceManager>();
	}
}
