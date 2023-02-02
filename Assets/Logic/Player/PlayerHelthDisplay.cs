using Logic.Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHelthDisplay : MonoBehaviour
{
    [SerializeField] private Slider m_slider = null;
    [SerializeField] private CharacterHealthReferenceHost m_playerHealthReferenceHost = null;

    private CharacterHealth m_playerHealth = null;
    
    private void Start()
    {
        m_playerHealth = m_playerHealthReferenceHost.Instance;
        
        if(m_playerHealth == null) return;
        m_playerHealth.OnHealthChanged += OnHealthChangedCallback;
    }

    private void OnDestroy()
    {
        if (m_playerHealth == null) return;
        m_playerHealth.OnHealthChanged -= OnHealthChangedCallback;
    }

    private void OnHealthChangedCallback() => m_slider.value = m_playerHealth.CurrentHealthPercent;
}
