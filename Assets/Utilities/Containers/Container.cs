using System.Collections;
using UnityEngine;
using Utilities.General;

namespace Utilities.Containers
{
	public class Container : MonoBehaviour
	{
		[SerializeField] private bool m_isOpen = false;
		[SerializeField] private IContainerAnimatorManager m_animationController;
		[SerializeField] private IContainerSpawnController m_containerSpawnController;

		private CoroutineManager m_coroutineManager = null;

		private void Awake()
		{
			m_coroutineManager = new CoroutineManager(this);
			m_animationController = gameObject.GetComponent<IContainerAnimatorManager>();
			m_containerSpawnController = gameObject.gameObject.GetComponent<IContainerSpawnController>();

		}

		private IEnumerator CloreCoroutine()
		{
			yield return m_animationController.Close();
			m_isOpen = false;
		}

		private IEnumerator OpenCoroutine()
		{
			yield return m_animationController.Open();
			//m_containerSpawnController.Spawn();
			m_isOpen = true;
		}

		public void Open()
		{
			if (m_isOpen == false)
				m_coroutineManager.Run(OpenCoroutine());
		}

		public void Close()
		{
			if (m_isOpen == true)
				m_coroutineManager.Run(CloreCoroutine());
		}
	}
}