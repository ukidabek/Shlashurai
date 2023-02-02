using System;
using UnityEngine;
using Weapons;

namespace Shlashurai.Player.Logic
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        public event Action<IDamage> OnDamageReceive;
        public void ReceiveDamage(IDamage damage) => OnDamageReceive?.Invoke(damage);
    }
}