using UnityEngine;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.States
{
	public class EnemyAttackAnimationStateLogic : StateLogic
	{
		[SerializeField] private EnemyAttackStateLogic m_enemyAttackStateLogic = null;
		[SerializeField] private Animator m_animator = null;
		[SerializeField] private AnimatorParameterDefinition m_chargeAttackAnimationParameterDefinition = null;
		[SerializeField] private AnimatorParameterDefinition m_attackAnimationParameterDefinition = null;

		public override void Activate()
		{
			base.Activate();
			m_enemyAttackStateLogic.AttackPhaseChanged += HandlePhaseChanging;
		}

		private void HandlePhaseChanging(EnemyAttackStateLogic.AttackPhase phase)
		{
			switch (phase)
			{
				case EnemyAttackStateLogic.AttackPhase.Charge:
					m_chargeAttackAnimationParameterDefinition.SetTrigger(m_animator);
					break;
				case EnemyAttackStateLogic.AttackPhase.Release:
					m_attackAnimationParameterDefinition.SetTrigger(m_animator);
					break;
			}
		}

		public override void Deactivate()
		{
			base.Deactivate();
			m_enemyAttackStateLogic.AttackPhaseChanged -= HandlePhaseChanging;
		}
	}
}