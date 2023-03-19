using UnityEngine;

namespace Weapons
{
    public interface IDamage
    {
        GameObject DamagingObject { get; }
        float Amount { get; }
    }
}