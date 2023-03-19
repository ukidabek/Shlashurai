using System;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public struct Damage : IDamage
    {
        [SerializeField] private float m_amount;
        public float Amount => m_amount;

        [SerializeField] private GameObject m_damagingObject;
        public GameObject DamagingObject => m_damagingObject;

		public Damage(float amount, GameObject damaging)
		{
			m_amount = amount;
			m_damagingObject = damaging;
		}

		public void SetAmount(float amount) => m_amount = amount;

		public void SetDamagingObject(GameObject damagingObject) => m_damagingObject = damagingObject;
	}
}