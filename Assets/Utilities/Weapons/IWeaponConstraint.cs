using UnityEngine;

namespace Weapons
{
    public interface IWeaponConstraint
    {
        bool Validate();
    }
}