using System;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public struct Damage : IDamage
    {
        [SerializeField] private float _amount;
        public float Amount => _amount;
    }
}