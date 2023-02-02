using UnityEngine;
using Utilities.States;

namespace Logic.Player
{
    [RequireComponent(typeof(CharacterHealth), typeof(StateSetter))]
    public class DeathStateEnforcer : MonoBehaviour
    {
        [SerializeField] private CharacterHealth m_CharacterHealth = null;
        [SerializeField] private StateSetter m_deathStateSetter = null;

        private void Reset()
        {
            m_CharacterHealth = GetComponent<CharacterHealth>();
            m_deathStateSetter = GetComponent<StateSetter>();
        }

        private void Awake()
        {
            m_CharacterHealth.OnDeath += EnforceDeathState;
        }

        private void OnDestroy()
        {
            m_CharacterHealth.OnDeath -= EnforceDeathState;
        }

        private void EnforceDeathState() => m_deathStateSetter.SetState();
    }
}