using UnityEngine;

namespace Shlashurai.Skills.Utilities
{
	public class RigidBodySpeedSetter : MonoBehaviour
	{
		[SerializeField] private Rigidbody m_rigidbody = null;
		[SerializeField] private float m_speed = 5;

		private void OnEnable()
		{
			m_rigidbody.velocity = transform.forward * m_speed;
		}
	}
}