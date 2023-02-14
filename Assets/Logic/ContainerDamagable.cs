using UnityEngine;
using Utilities.Containers;
using Weapons;

namespace Shlashurai.Containers
{
	[RequireComponent(typeof(Container))]
	public class ContainerDamagable : MonoBehaviour, IDamageable
	{
		[SerializeField] private Container m_container = null;

		public void ReceiveDamage(IDamage damage)
		{
			m_container.Open();
		}

		private void Reset()
		{
			m_container = GetComponent<Container>();
		}
	}
}