using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.States;
using Weapons;

namespace Shlashurai.Player.Logic
{
    public class DamageDealerStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic
    {
        [SerializeField] private InputValues m_inputValues = null;
        [SerializeField] private float m_radius = 5f;
        [SerializeField] private float m_attackInterval = 0.3f;
        [SerializeField] private float m_counter = 0f;
        [SerializeField] private Transform m_model = null;
        [SerializeField] private Animator m_animator = null;
        [SerializeField] private string m_attackTriggerName = string.Empty;
        [SerializeField] private Damage m_damage = new Damage(5f);
        [SerializeField] private LayerMask m_dealDamageLayer = new LayerMask();
        
        private readonly Collider[] m_colliders = new Collider[10];
        private int m_attackTriggerHash = 0;

        private void Awake()
        {
            m_attackTriggerHash = Animator.StringToHash(m_attackTriggerName);
        }

        public void OnUpdate(float deltaTime)
        {
            if (m_counter >= 0f)
                m_counter -= Time.deltaTime;
            
            if (!m_inputValues.Attack ) return;
            m_inputValues.Attack = false;
            
            if(m_counter > 0f) return;
            m_counter = m_attackInterval;
            m_animator.SetTrigger(m_attackTriggerHash);
            
            var count = Physics.OverlapSphereNonAlloc(transform.position, m_radius, m_colliders, m_dealDamageLayer);
            if (count <= 0) return;

            var position = m_model.position;
            var forward = m_model.forward;
            
            for (var i = 0; i < count; i++)
            {
                var targetPosition = m_colliders[i].transform.position;
                var fromTo = targetPosition - position;
                fromTo.Normalize();
                
                var dot = Vector3.Dot(fromTo, forward);
                if(dot < 0) continue;

                var damageable = m_colliders[i].GetComponent<IDamageable>();
                damageable?.ReceiveDamage(m_damage);
            }
        }
    }
}