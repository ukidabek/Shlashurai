using UnityEngine;
using Utilities.States;

namespace Shlashurai.Characters
{
    [RequireComponent(typeof(ResourceManager), typeof(StateSetter))]
    public class DeathStateEnforcer : MonoBehaviour
    {
        [SerializeField] private ResourceID m_healthResourceId = null;
        [SerializeField] private ResourceManager m_resourceManager = null;
        [SerializeField] private StateSetter m_deathStateSetter = null;
        
        private Resource m_resource = null;
        private void Reset()
        {
            m_resourceManager = GetComponent<ResourceManager>();
        }

        private void Awake()
        {
			m_resource = m_resourceManager.GetResource(m_healthResourceId);
            
            if (m_resource == null) return;
			m_resource.OnValueChanged += EnforceDeathState;
        }

        private void OnDestroy()
        {
			if (m_resource == null) return;
			m_resource.OnValueChanged -= EnforceDeathState;
		}

		private void EnforceDeathState()
		{
            if (m_resource.CurrentValue > 0) return;
			m_deathStateSetter.SetState();
		}
	}
}