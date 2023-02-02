﻿using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
    public class SlashDamageDealerStateLogic : StateLogicMonoBehaviour
    {
        [SerializeField] private OnCollisionEnterHandler m_hitHandler = null;
        [SerializeField] private float m_radius = 5f;
        [SerializeField] private float m_damage = 5f;
        
        private readonly Collider[] m_colliders = new Collider[10];
        
        public override void Activate()
        {
            base.Activate();
            m_hitHandler.OnControllerColliderHitCallback += OnControllerColliderHit;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            m_hitHandler.OnControllerColliderHitCallback -= OnControllerColliderHit;
        }

        private void OnControllerColliderHit(Collision obj)
        {
            var count = Physics.OverlapSphereNonAlloc(transform.position, m_radius, m_colliders);
            if (count <= 0) return;
            for (var i = 0; i < count; i++)
            {
                var damageable = m_colliders[i].GetComponent<IDamageable>();
                damageable?.ReceiveDamage(m_damage);
            }
        }
    }
}