using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
    public class MovementStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic, IOnFixUpdateLogic
    {
        [SerializeField] private Transform m_root = null;
        [SerializeField] private InputValues m_inputValues = null;
        [SerializeField] private Rigidbody m_controlelr = null;
        [SerializeField] private float m_speed = 3;
        [SerializeField] private bool m_freazDirections = false;

        private Vector3 m_frezedForwardDirection, m_frezedRightDirection, m_input;
        
        public override void Activate()
        {
            base.Activate();

            m_frezedForwardDirection = m_root.forward;
            m_frezedRightDirection = m_root.right;
        }

        public void OnUpdate(float deltaTime) => m_input = m_inputValues.Move;

        public void OnFixUpdate(float deltaTime)
        {
            var forward = m_freazDirections ? m_frezedForwardDirection : m_root.forward;
            var right = m_freazDirections ? m_frezedRightDirection : m_root.right;

            forward *= m_speed *  m_input.y;
            right *= m_speed *  m_input.x;

            var direction = forward + right;
            m_controlelr.velocity = direction;
        }
    }
}