using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Characters
{
	public class ResourceManager : MonoBehaviour
	{
		[SerializeField] private Resource[] m_resources = null;
		public IEnumerable<Resource> Resources => m_resources;

		private Dictionary<ResourceID, Resource> m_resourceDictionary = new Dictionary<ResourceID, Resource>(); 

		private void Awake()
		{
			InitializeDictionary();
		}

		private void InitializeDictionary()
		{
			if(m_resourceDictionary.Count > 0) return;
			
			foreach (var resource in m_resources)
				m_resourceDictionary.Add(resource.ID, resource);
		}

		private void Start()
		{
			foreach (var item in m_resources)
				item.Reset();
		}

		private void OnEnable()
		{
			foreach (var item in m_resources)
				item.Reset();
		}

		public Resource GetResource(ResourceID resourceID)
		{
			InitializeDictionary();

			if (m_resourceDictionary.TryGetValue(resourceID, out var resource))
				return resource;

			return null;
		}
	}
}