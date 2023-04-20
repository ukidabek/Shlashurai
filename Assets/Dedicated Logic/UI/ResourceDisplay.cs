using Shlashurai.Characters;
using System;
using System.Linq;
using UnityEngine;
using Utilities.ReferenceHost;

namespace Shlashurai.UI
{
	public class ResourceDisplay : MonoBehaviour
	{
		[SerializeField, Inject] private ResourceManager m_resourceManager = null;
		[SerializeField] private ResourceSliderDisplayModel[] m_resourceDisplays = null;

		public void InitializeResourceSliders()
		{
			var list = Array.Empty<SliderDisplayModel>()
				.Concat(m_resourceDisplays.Select(model =>
				{
					model.ResourceManager = m_resourceManager;
					return model;
				}));
			foreach (var item in list)
				item.Initialize();
		}
	}
}