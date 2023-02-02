using Logic.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Shlashurai.Enemy.Logic
{
    public class EnemyHealthDisplay : MonoBehaviour
    { 
        [SerializeField] private CharacterHealth m_characterHealth = null;
        [SerializeField] private Slider m_slider = null;
        
        private void Awake()
        {
            m_characterHealth.OnHealthChanged += UpdateDisplay;
        }

        private void OnDestroy()
        {
            m_characterHealth.OnHealthChanged -= UpdateDisplay;
        }

        private void UpdateDisplay() => m_slider.value = m_characterHealth.CurrentHealthPercent;
    }
}