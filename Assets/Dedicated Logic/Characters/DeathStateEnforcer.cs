using UnityEngine;
using Utilities.States;

namespace Shlashurai.Characters
{
    [RequireComponent(typeof(ResourceManager), typeof(StateSetter))]
    public class DeathStateEnforcer : MonoBehaviour, ISwitchStateCondition
    {
        [SerializeField] private ResourceID m_healthResourceId = null;
        [SerializeField] private ResourceManager m_resourceManager = null;
        [SerializeField] private StateSetter m_deathStateSetter = null;

        [SerializeField] private SwitchStateStateLogicReferenceHost m_switchStateStateLogicReferenceHost = null;
        
        private Resource m_resource = null;

        public bool Condition => m_resource.Value <= 0;

		private void Reset()
        {
            m_resourceManager = GetComponent<ResourceManager>();
        }

        private void Start()
        {
			m_resource = m_resourceManager.GetResource(m_healthResourceId);

            if (m_switchStateStateLogicReferenceHost != null)
            {
                var instance = m_switchStateStateLogicReferenceHost.Instance;
                instance?.AddCondition(this);
            }

			if (m_resource == null) return;
			m_resource.OnValueChanged += EnforceDeathState;
        }

        private void OnDestroy()
        {
            if (m_switchStateStateLogicReferenceHost != null)
            {
                var instance = m_switchStateStateLogicReferenceHost.Instance;
                instance?.RemoveCondition(this);
            }

			if (m_resource == null) return;
			m_resource.OnValueChanged -= EnforceDeathState;
		}

		private void EnforceDeathState()
		{
            if (m_resource.Value > 0) return;
			m_deathStateSetter.SetState();
		}
	}
}