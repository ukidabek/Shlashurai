using Shlashurai.Characters;
using Shlashurai.Player;
using System;
using UnityEngine;

[Serializable]
public class ResourceSliderDisplayModel : SliderDisplayModel
{
    [SerializeField] private ResourceManagerReferenceHost m_resourceManagerReferenceHost = null;
	[SerializeField] private ResourceID m_resourceID = null;

	private Resource Resource { get; set; }

    public override float Percent => Resource.Percent;

	public override event Action OnValueChanged;

	protected override void PreProcess()
	{
		var instance = m_resourceManagerReferenceHost.Instance;
		Resource = instance.GetResource(m_resourceID);
        Resource.OnValueChanged += HandleEvent;
	}

	private void HandleEvent() => OnValueChanged?.Invoke();
}
