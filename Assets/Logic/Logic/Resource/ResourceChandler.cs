using Mono.Cecil;
using System;
using UnityEngine;

namespace Shlashurai.Characters
{
	[Serializable]
	public class ResourceChandler
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

		private void GetResource()
		{
			if (m_resource == null)
				m_resource = m_resourceManager.GetResource(m_resourceID);
		}
	}
}