using System;
using UnityEngine;

namespace Weapons
{

    [Serializable]
    public struct Damage : IDamage
    {
        [SerializeField] private float m_amount;
        public float Amount => m_amount;

        public Damage(float amount)
        {
            m_amount = amount;
        }

		public void SetAmount(float amount) => m_amount = amount;
	}
}