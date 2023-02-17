using UnityEngine;

namespace Logic.SkillEffectsUtilities
{
	public class OnDistanceDisabler : MonoBehaviour
	{
		[SerializeField] private float m_maxDistance = 10;
		private Vector3 m_startPosition = Vector3.zero;
		private void OnEnable()
		{
			m_startPosition = transform.position;
		}

		private void Update()
		{
			var position = transform.position;

			if (Vector3.Distance(m_startPosition, position) >= m_maxDistance)
				gameObject.SetActive(false);
		}
	}
}