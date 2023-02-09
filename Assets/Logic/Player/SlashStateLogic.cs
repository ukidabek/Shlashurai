using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
    public class SlashStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic, IOnFixUpdateLogic, ISwitchStateCondition
    {
        [SerializeField] private Rigidbody m_controller = null;
        [SerializeField] private OnCollisionEnterHandler m_hitHandler = null;
        [SerializeField] private Transform m_root = null;
        [Space]
        [SerializeField] private float m_range = 5f;
        [SerializeField] private float m_slashSpeed = 50f;
        [SerializeField] private float m_stopDistance = 0.1f;
        [Space] 
        [SerializeField] private Animator m_animator = null;
        [SerializeField] private string m_triggerName = null;
        private int m_triggerNameHans = 0;

        private Vector3 m_startPosition;
        private Vector3 m_endPosition;
        private Vector3 m_direction;
        
        public bool Condition { get; private set; }

        private void Awake()
        {
            m_triggerNameHans = Animator.StringToHash(m_triggerName);
        }

        public override void Activate()
        {
            base.Activate();
            Condition = false;
            m_startPosition = m_controller.transform.position;
            m_endPosition = m_startPosition + m_root.forward * m_range;
            m_direction = m_endPosition - m_startPosition;
            m_direction.Normalize();
            m_hitHandler.OnControllerColliderHitCallback += OnControllerColliderHit;
        }

        private void OnControllerColliderHit(Collision other)
        {
            Condition = true;
            m_animator.SetTrigger(m_triggerNameHans);
            m_hitHandler.OnControllerColliderHitCallback -= OnControllerColliderHit;
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
				Condition = true;
		}

		public void OnFixUpdate(float deltaTime)
        {
            var movement = m_direction * m_slashSpeed;
            m_controller.velocity = movement;
        }
	}
}