using Shlashurai.Characters;
using Shlashurai.Statistics;
using UnityEngine;

public abstract class StatisticToResourceApplyLogic : StatisticApplyLogic
{
	[SerializeField] protected ResourceManager m_resourceManager = null;
	[SerializeField] protected ResourceID m_resourceID = null;

	[ContextMenu("GetResourceManager")]
	private void GetResourceManager()
	{
		var root = transform.root;
		m_resourceManager = root.GetComponent<ResourceManager>();
	}
}
