using Shlashurai.Items;
using System.Linq;
using UnityEngine;

public class SimpleItemSpawner : MonoBehaviour
{
	[SerializeField] private ItemTemplate m_itemTemplate = null;

	private void Start()
	{
		var item = m_itemTemplate.Create();
		
		item.IsActive = true;
		var managableComponents = item.Components.OfType<IManageableItemComponent>();
		foreach (var component in managableComponents)
		{
			component.SetActive(true);
			if (component is ItemPrefabComponent prefabComponent)
			{
				var instanceTransform = prefabComponent.Instance.transform;
				instanceTransform.position = transform.position;
			}
		}
	}
}
