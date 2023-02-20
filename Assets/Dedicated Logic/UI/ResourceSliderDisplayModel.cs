using Shlashurai.Characters;
using System;
using UnityEngine;

[Serializable]
public class ResourceSliderDisplayModel : SliderDisplayModel
{
    [SerializeField] private ResourceManager m_resourceManager = null;
    public ResourceManager ResourceManager 
	{ 
		get => m_resourceManager; 
		set => m_resourceManager = value; 
	}

    [SerializeField] private ResourceID m_resourceID = null;

	private Resource Resource { get; set; }

    public override float Percent => Resource.Percent;

	public override event Action OnValueChanged;

	protected override void PreProcess()
	{
		var instance = m_resourceManager;
		Resource = instance.GetResource(m_resourceID);
        Resource.OnValueChanged += HandleEvent;
	}

	private void HandleEvent() => OnValueChanged?.Invoke();
}
