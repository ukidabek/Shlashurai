using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Utilities.General;
using Utilities.States;
using Weapons;

namespace Shlashurai.Enemy.Logic
{
    public class EnemyAttackStateLogic : StateLogicMonoBehaviour, ISwitchStateCondition
    {
        [SerializeField] private float m_waitBeforeAttack = 1f;
        [SerializeField] private float m_waitAfterAttack = 1f;
        [SerializeField] private NavMeshAgent m_navMeshAgent = null;
        [SerializeField] private Animator m_animator = null;
        [SerializeField] private AnimatorParameterDefinition m_attackTrigger = null;
        [SerializeField] private Transform m_model;
        [SerializeField] private float m_radius = 5f;
        [SerializeField] private Damage m_damage = new Damage(5f);
        [SerializeField] private LayerMask m_dealDamageMask = new LayerMask();

        private readonly Collider[] m_colliders = new Collider[10];


        private bool m_attackFinished = false;
        private Coroutine m_coroutine = null;

        private CoroutineManager m_coroutineManager;

        public bool Condition => m_attackFinished;

        private void Awake()
        {
            m_coroutineManager = new CoroutineManager(this);
        }

        public override void Activate()
        {
            base.Activate();
            m_coroutineManager.Run(AttackCoroutine());
            m_attackFinished = false;
            m_navMeshAgent.SetDestination(transform.position);
        }
        
        private IEnumerator AttackCoroutine()
        {
            yield return new WaitForSeconds(m_waitBeforeAttack);
            
            m_attackTrigger.SetTrigger(m_animator);
            
            var count = Physics.OverlapSphereNonAlloc(transform.position, m_radius, m_colliders, m_dealDamageMask);
            if (count > 0)
            {
                var position = m_model.position;
                var forward = m_model.forward;

                for (var i = 0; i < count; i++)
                {
                    var targetPosition = m_colliders[i].transform.position;
                    var fromTo = targetPosition - position;
                    fromTo.Normalize();

                    var dot = Vector3.Dot(fromTo, forward);
                    if (dot < 0) continue;

                    var damageable = m_colliders[i].GetComponent<IDamageable>();
                    damageable?.ReceiveDamage(m_damage);
                }
            }

            yield return new WaitForSeconds(m_waitAfterAttack);
            m_attackFinished = true;
        }
    }
}