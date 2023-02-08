using System;
using UnityEngine;
using Weapons;

namespace Logic.Player
{
	public class CharacterHealth : MonoBehaviour
	{
		[SerializeField] private float m_initialHealth = 100;

		[SerializeField] private float m_currentHealth = 0;
		public float CurrentHealth => m_currentHealth;
		public float CurrentHealthPercent => Mathf.Clamp01(m_currentHealth / m_initialHealth);

		[SerializeField] private Component m_damagableComponent = null;
		private IDamageable m_damagable = null;

		public event Action OnHealthChanged = null;
		public event Action OnDeath = null;

		private void Awake()
		{
			m_damagable = m_damagableComponent as IDamageable;
			if (m_damagable == null) return;
			m_damagable.OnDamageReceive += DamageReceiveCallback;
		}

		private void Start() => ResetHealth();

		private void OnEnable() => ResetHealth();

		private void DamageReceiveCallback(IDamage damage)
		{
			if (m_currentHealth <= 0) return;

			m_currentHealth -= damage.Amount;
			OnHealthChanged?.Invoke();

			if (m_currentHealth <= 0)
				OnDeath?.Invoke();
		}

		public void ResetHealth()
		{
			m_currentHealth = m_initialHealth;
			OnHealthChanged?.Invoke();
		}
	}
}