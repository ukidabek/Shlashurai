using UnityEngine;

namespace Logic.SkillEffectsUtilities
{
	public class RigidBodySpeedSetter : MonoBehaviour
	{
		[SerializeField] private Rigidbody m_rigidbody = null;
		[SerializeField] private float m_speed = 5;
		[SerializeField] private float m_maxDistance = 10;

		private Vector3 m_startPosition = Vector3.zero;

		private void OnEnable()
		{
			m_startPosition = transform.position;
			m_rigidbody.velocity = transform.forward * m_speed;
		}

		private void Update()
		{
			var position = transform.position;

			if (Vector3.Distance(m_startPosition, position) >= m_maxDistance)
				gameObject.SetActive(false);
		}
	}
}