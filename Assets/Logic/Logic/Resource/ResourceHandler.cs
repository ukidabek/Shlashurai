using System;
using UnityEngine;

namespace Shlashurai.Characters
{
	[Serializable]
	public class ResourceHandler
	{
		[SerializeField] private ResourceID m_resourceID = null;
		public ResourceID ResourceID
		{
			get => m_resourceID;
			set => m_resourceID = value;
		}

		[SerializeField] private ResourceManager m_resourceManager = null;
		public ResourceManager ResourceManager
		{
			get => m_resourceManager;
			set => m_resourceManager = value;
		}

		private Resource m_resource = null;

		public float Value
		{
			get
			{
				GetResource();
				return m_resource.Value;
			}
			set
			{
				GetResource();
				m_resource.Value = value;
			}
		}

		public float Percent
		{
			get
			{
				GetResource();
				return m_resource.Percent;
			}
		}

		public ResourceHandler()
		{
		}

		public ResourceHandler(ResourceID resourceID, ResourceManager resourceManager)
		{
			m_resourceID = resourceID;
			m_resourceManager = resourceManager;
			GetResource();
		}

		private void GetResource()
		{
			if (m_resource == null)
				m_resource = m_resourceManager.GetResource(m_resourceID);
		}
	}
}