using UnityEngine;

namespace Shlashurai.Player.Input
{
    [CreateAssetMenu(menuName = "Shlashurai/Input/InputValues", fileName = "InputValues")]
    public class InputValues : ScriptableObject
    {
        [SerializeField] private Vector2 move = Vector2.zero;
        public Vector2 Move
        {
            get => move;
            set => move = value;
        }
        
        [SerializeField] private Vector2 m_look = Vector2.zero;
        public Vector2 Look
        {
            get => m_look;
            set => m_look = value;
        }

        [SerializeField] private bool m_slash = false;
        public bool Slash
        {
            get => m_slash;
            set => m_slash = value;
        }

        [SerializeField] private bool m_attack = false;
        public bool Attack
        {
            get => m_attack; 
            set => m_attack = value; 
        }
    }
}