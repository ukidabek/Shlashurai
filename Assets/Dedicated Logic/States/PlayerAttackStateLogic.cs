using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{

	public class PlayerAttackStateLogic : AttackStateLogicBase, IOnUpdateLogic
	{
		[SerializeField] private InputValues m_inputValues = null;
		[SerializeField] private float m_attackInterval = 0.3f;
		[SerializeField] private float m_counter = 0f;
		[SerializeField] private Transform m_model = null;
		[SerializeField] private DamageDealingHandler m_damageDealingHandler = new DamageDealingHandler();

		public override bool PerformingAttack { get; protected set; }

		public void OnUpdate(float deltaTime, float timeScale)
		{
			if (m_counter >= 0f)
				m_counter -= Time.deltaTime;

			PerformingAttack = m_inputValues.Attack && m_counter <= 0f;

			if (!PerformingAttack)
				return;

			m_counter = m_attackInterval;
			var position = m_model.position;
			var forward = m_model.forward;
			m_damageDealingHandler.DealDamage(position, forward);
		}
	}
}