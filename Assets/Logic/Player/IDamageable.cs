using System;

namespace Shlashurai.Player.Logic
{
    public interface IDamageable
    {
        public event Action<float> OnDamageReceive; 
        void ReceiveDamage(float damage);
    }
}