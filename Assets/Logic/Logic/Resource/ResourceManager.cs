using System;
using System.Linq;
using UnityEngine;
using Weapons;

namespace Shlashurai.Characters
{
	public class ResourceManager : MonoBehaviour
	{
		[SerializeField] private Resource[] m_resources = null;

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

		public Resource GetResource(ResourceID resourceID) => m_resources.FirstOrDefault(resource => resource.ID == resourceID);
	}
}