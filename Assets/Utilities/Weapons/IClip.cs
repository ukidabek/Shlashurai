using System;

namespace Weapons
{
    public interface IClip 
    {
       int Counter { get; }
       int Count { get; }
       void Reload(int amount = -1);
       WeaponDescriptor AmmunitionType { get; }
       event Action<int> OnCounterChange;
    }
}