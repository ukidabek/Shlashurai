using Logic.States;
using Shlashurai.Player.Input;
using UnityEngine;

namespace Shlashurai.Player.Logic
{
    public class RotateStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic
    {
        [SerializeField] private Transform m_root = null;
        [SerializeField] private InputValues m_inputValues = null;
        [SerializeField] private float m_speed = 10;

        public float SpeedMultiplayer { get; set; } = 1f;
        
        private Vector3 up = Vector3.up;
        private Vector3 direction = Vector3.zero;
        
        public void OnUpdate(float deltaTime)
        {
            var look = m_inputValues.Look;
            direction.Set(look.x, 0, look.y);
            var rotation = Quaternion.LookRotation(direction, up);
            var speed = m_speed / SpeedMultiplayer;
            m_root.rotation = Quaternion.RotateTowards(m_root.rotation, rotation, speed);
        }
    }
}