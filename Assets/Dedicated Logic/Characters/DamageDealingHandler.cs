using System;
using UnityEngine;
using Weapons;

namespace Shlashurai.Player.Logic
{
	[Serializable]
	public class DamageDealingHandler 
	{
		[SerializeField] private float m_radius = 5f;
		public float Radius
		{
			get => m_radius;
			set => m_radius = value;
		}

		[SerializeField] private float m_damageAmount = 10f;
		public float DamageAmount
		{
			get => m_damageAmount;
			set => m_damageAmount = value;
		}

		[SerializeField] private bool m_directionalDamage = true;
		public float DirectionalDamage
		{
			get => m_damageAmount;
			set => m_damageAmount = value;
		}

		[SerializeField] private LayerMask m_dealDamageLayer = new LayerMask();

		[SerializeField, Range(0f, 1f)] private float m_damageSpread = 0f;
		public float DamageSpread
		{
			get => m_damageSpread;
			set => m_damageSpread = Mathf.Clamp01(value);
		}

		private Collider[] m_colliders = new Collider[20];
		private Damage m_damage = new Damage();

		public void DealDamage(Vector3 position, Vector3 forward)
		{
			var count = Physics.OverlapSphereNonAlloc(position, m_radius, m_colliders, m_dealDamageLayer);
			if (count <= 0) return;

			m_damage.SetAmount(m_damageAmount);

			for (var i = 0; i < count; i++)
			{
				var targetPosition = m_colliders[i].transform.position;
				var fromTo = targetPosition - position;
				fromTo.Normalize();

				if (m_directionalDamage)
				{
					var dot = Vector3.Dot(fromTo, forward);
					if (dot < m_damageSpread) continue;
				}

				var damageable = m_colliders[i].GetComponent<IDamageable>();
				damageable?.ReceiveDamage(m_damage);
			}
		}
	}
}