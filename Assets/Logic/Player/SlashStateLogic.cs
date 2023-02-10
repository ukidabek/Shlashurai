using Shlashurai.Logic;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
    public class SlashStateLogic : OnCollisionEnterStateLogic, IOnUpdateLogic, IOnFixUpdateLogic, ISwitchStateCondition
    {
        [SerializeField] private Rigidbody m_controller = null;
		[SerializeField] private Transform m_root = null;
        [Space]
        [SerializeField] private float m_range = 5f;
        [SerializeField] private float m_slashSpeed = 50f;
        [SerializeField] private float m_stopDistance = 0.1f;

        private Vector3 m_startPosition;
        private Vector3 m_endPosition;
        private Vector3 m_direction;

        private readonly Vector3 m_zeroSpeed = Vector3.zero;
        
        public bool Condition { get; private set; }

        protected override CollisionHandlingMode CollisionHandling => CollisionHandlingMode.First;

		public override void Activate()
        {
            base.Activate();
            Condition = false;
            m_startPosition = m_controller.transform.position;
            m_endPosition = m_startPosition + m_root.forward * m_range;
            m_direction = m_endPosition - m_startPosition;
            m_direction.Normalize();
        }

		public override void Deactivate()
        {
            base.Deactivate();
            Condition = false;
        }

        public void OnUpdate(float deltaTime)
        {
            var distance = Vector3.Distance(m_controller.transform.position, m_endPosition);
			if (distance <= m_stopDistance)
			{
				Condition = true;
				m_controller.velocity = m_zeroSpeed;
			}
		}

		public void OnFixUpdate(float deltaTime)
        {
            if (Condition) return;
            var movement = m_direction * m_slashSpeed;
            m_controller.velocity = movement;
        }

		protected override void HandleCollision(Collision other)
		{
			Condition = true;
			m_controller.velocity = m_zeroSpeed;
		}
	}
}