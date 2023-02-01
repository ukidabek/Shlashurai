using System;
using UnityEngine;

namespace Shlashurai.Player.Logic
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        public event Action<float> OnDamageReceive;
        public void ReceiveDamage(float damage) => OnDamageReceive?.Invoke(damage);
    }
}