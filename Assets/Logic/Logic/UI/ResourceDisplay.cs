using Shlashurai.Characters;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private Slider m_slider = null;
    [SerializeField] private ResourceID m_resourceID = null;
    [SerializeField] private ResourceManager m_resourceManager = null;

    private Resource m_resource = null;
    
    private void Awake()
    {
        Initialize(m_resourceManager);
    }

    public void Initialize(ResourceManager resourceManager)
    {
        m_resourceManager = resourceManager;

        if (m_resourceManager == null) return;
        m_resource = m_resourceManager.GetResource(m_resourceID);

        if (m_resource == null) return;
        m_resource.OnValueChanged += OnValueChangedCallback;
    }

    private void OnDestroy()
    {
        if (m_resource == null) return;
		m_resource.OnValueChanged -= OnValueChangedCallback;
    }

    private void OnValueChangedCallback() => m_slider.value = m_resource.Percent;
}
