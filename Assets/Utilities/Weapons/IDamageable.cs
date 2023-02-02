using System;

namespace Weapons
{
    public interface IDamageable
    {
        event Action<IDamage> OnDamageReceive;
        void ReceiveDamage(IDamage damage);
    }
}