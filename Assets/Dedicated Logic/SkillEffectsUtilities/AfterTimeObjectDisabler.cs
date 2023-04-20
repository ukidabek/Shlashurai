using System.Collections;
using UnityEngine;

namespace Shlashurai.Skills.Utilities
{
	public class AfterTimeObjectDisabler : MonoBehaviour
	{
		[SerializeField] private float m_timeToWait = 1f;

		private WaitForSeconds m_wait = null;

		private void Awake() => m_wait = new WaitForSeconds(m_timeToWait);

		private void OnEnable() => StartCoroutine(WaitAndDisable());

		private IEnumerator WaitAndDisable()
		{
			yield return m_wait;
			gameObject.SetActive(false);
		}
	}
}