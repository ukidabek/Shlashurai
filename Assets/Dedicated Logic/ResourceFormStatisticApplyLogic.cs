using Shlashurai.Characters;
using Shlashurai.Statistics;
using UnityEngine;

public class ResourceFormStatisticApplyLogic : StatisticApplyLogic
{
	[SerializeField] private ResourceManager m_resourceManager = null;
	[SerializeField] private ResourceID m_resourceID = null;

	[SerializeField] private float m_resourceAmountPerStatisticPoint = 5; 

	public override void Apply()
	{
		var resource = m_resourceManager.GetResource(m_resourceID);
		resource.MaxValue = m_resourceAmountPerStatisticPoint * m_statisticToApply.Value;
	}

	[ContextMenu("GetResourceManager")]
	private void GetResourceManager()
	{
		var root = transform.root;
		m_resourceManager = root.GetComponent<ResourceManager>();
	}
}
