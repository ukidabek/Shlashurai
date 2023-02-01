using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons
{
    [Serializable] public class OnHitCallback : UnityEvent<Damage, GameObject> { }

    public class HitInvoker : MonoBehaviour
    {
        [SerializeField] private  Damage _damage;
        public Damage Damage { get => _damage; set => _damage = value; }

        [Space]
        public OnHitCallback OnHit = new OnHitCallback();

        private void OnTriggerEnter(Collider other)
        {
            var hit = other.gameObject.GetComponent<IDamageable>();
            if (hit == null) return;
            hit.DealDamage(_damage);
            OnHit.Invoke(_damage, other.gameObject);
        }
    }
}