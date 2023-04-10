using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class RotateStateLogic : StateLogic, IOnUpdateLogic
    {
        [SerializeField] private Transform m_root = null;
        [SerializeField] private InputValues m_inputValues = null;
        [SerializeField] private float m_speed = 10;
        
        private Vector3 up = Vector3.up;
        private Vector3 direction = Vector3.zero;
        
        public void OnUpdate(float deltaTime, float timeScale)
		{
            var look = m_inputValues.Look;
            direction.Set(look.x, 0, look.y);
            var rotation = Quaternion.LookRotation(direction, up);
            var speed = m_speed * timeScale;
            m_root.rotation = Quaternion.RotateTowards(m_root.rotation, rotation, speed);
        }
    }
}