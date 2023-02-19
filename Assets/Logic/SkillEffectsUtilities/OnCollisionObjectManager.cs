using UnityEngine;

namespace Logic.SkillEffectsUtilities
{
	public class OnCollisionObjectManager : MonoBehaviour
	{
		[SerializeField] private GameObject[] m_gameObjectsToDisable = null;
		[SerializeField] private GameObject[] m_gameObjectsToEnable = null;

		private void OnCollisionEnter(Collision collision)
		{
			foreach (var obj in m_gameObjectsToDisable)
				obj.SetActive(false);

			foreach (var obj in m_gameObjectsToEnable)
				obj.SetActive(true);
		}

		private void OnDisable()
		{
			foreach (var obj in m_gameObjectsToDisable)
				obj.SetActive(true);

			foreach (var obj in m_gameObjectsToEnable)
				obj.SetActive(false);
		}
	}
}