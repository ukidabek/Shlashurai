using Shlashurai.Logic;
using UnityEngine;
using Utilities.States;
using Utilities.Values;

namespace Shlashurai.Player.Logic
{
    public class SlashStateLogic : OnCollisionEnterStateLogic, IOnUpdateLogic, IOnFixUpdateLogic, ISwitchStateCondition
    {
        [SerializeField] private Rigidbody m_controller = null;
		[SerializeField] private Transform m_root = null;
        [Space]
        [SerializeField] private FloatValue m_range = null;
        [SerializeField] private FloatValue m_slashSpeed = null;
        [SerializeField] private FloatValue m_stopDistance = null;

        private Vector3 m_startPosition;
        private Vector3 m_endPosition;
        private Vector3 m_direction;
        
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

        public void OnUpdate(float deltaTime, float timeScale)
		{
            var distance = Vector3.Distance(m_controller.position, m_endPosition);
			if (distance <= m_stopDistance)
				Condition = true;
		}

		public void OnFixUpdate(float deltaTime, float timeScale)
		{
            if (Condition) return;
            var movement = m_controller.position + m_direction * (m_slashSpeed * deltaTime * timeScale);
            m_controller.MovePosition(movement);
        }

		protected override void HandleCollision(Collision other) => Condition = true;
	}
}