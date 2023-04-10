using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public abstract class AttackStateLogic : StateLogic, IOnUpdateLogic, IDamageDealingLogic
	{
		[SerializeField] protected DamageDealingHandler m_damageDealingHandler = new DamageDealingHandler();
		[SerializeField] private float m_attackInterval = 0.3f;
		[SerializeField] private float m_counter = 0f;
		[SerializeField] private Transform m_model = null;		
		[SerializeField] protected float m_damageAmount = 10f;
		public float DamageAmount
		{
			get => m_damageAmount;
			set => m_damageAmount = value;
		}
		public virtual bool PerformingAttack { get; protected set; }
		public abstract bool PerformAttack { get; }
		public WeaponItemComponent WeaponItemComponent { get; set; }

		public void OnUpdate(float deltaTime, float timeScale)
		{
			if (m_counter >= 0f)
				m_counter -= Time.deltaTime;

			PerformingAttack = PerformAttack && m_counter <= 0f;

			if (!PerformingAttack) return;

			var weaponDamage = 0f;
			var attackInterval = m_attackInterval;
			if (WeaponItemComponent != null)
			{
				weaponDamage = WeaponItemComponent.GetDamage();
				attackInterval = WeaponItemComponent.AttackInterval;
			}

			m_damageDealingHandler.DamageAmount = DamageAmount + weaponDamage;

			m_counter = attackInterval;
			var position = m_model.position;
			var forward = m_model.forward;
			m_damageDealingHandler.DealDamage(position, forward);
		}
	}
}