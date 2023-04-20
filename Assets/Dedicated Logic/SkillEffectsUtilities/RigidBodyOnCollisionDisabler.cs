using UnityEngine;

namespace Shlashurai.Skills.Utilities
{
	public class RigidBodyOnCollisionDisabler : MonoBehaviour
	{
		[SerializeField] private Rigidbody m_rigidbody = null;

		private void OnCollisionEnter(Collision collision)
		{
			m_rigidbody.isKinematic = true;
		}

		private void OnDisable()
		{
			m_rigidbody.isKinematic = false;
		}

		private void Reset()
		{
			m_rigidbody = GetComponent<Rigidbody>();
		}
	}
}