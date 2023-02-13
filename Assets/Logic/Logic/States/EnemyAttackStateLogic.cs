using Shlashurai.Player.Logic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.Enemy.Logic
{
	public class EnemyAttackStateLogic : StateLogicMonoBehaviour, ISwitchStateCondition
    {
        public enum AttackPhase
        {
            None,
            Charge,
            Release,
            Recall
        }

        [SerializeField] private float m_waitBeforeAttack = 1f;
        [SerializeField] private float m_waitAfterAttack = 1f;
        [SerializeField] private NavMeshAgent m_navMeshAgent = null;

        [SerializeField] private Transform m_model;

		[SerializeField] private DamageDealingHandler m_damageDealingHandler = new DamageDealingHandler();

        private CoroutineManager m_coroutineManager;

        public bool Condition => m_attackPhase == AttackPhase.Recall;

        public event Action<AttackPhase> AttackPhaseChanged = null;
        [SerializeField] private AttackPhase m_attackPhase = AttackPhase.None;
     
		private void Awake()
        {
            m_coroutineManager = new CoroutineManager(this);
        }

        public override void Activate()
        {
            base.Activate();
            m_coroutineManager.Run(AttackCoroutine());
            m_navMeshAgent.SetDestination(transform.position);
        }

		private void SetPhase(AttackPhase phase) => AttackPhaseChanged?.Invoke(m_attackPhase = phase);


		private IEnumerator AttackCoroutine()
        {
			SetPhase(AttackPhase.Charge);

			yield return new WaitForSeconds(m_waitBeforeAttack);

            SetPhase(AttackPhase.Release);

			var position = m_model.position;
			var forward = m_model.forward;
			m_damageDealingHandler.DealDamage(position, forward);

			yield return new WaitForSeconds(m_waitAfterAttack);

			SetPhase(AttackPhase.Recall);
		}

		public override void Deactivate()
		{
			base.Deactivate();
			SetPhase(AttackPhase.None);
		}
	}
}