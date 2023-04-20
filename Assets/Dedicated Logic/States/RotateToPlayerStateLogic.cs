using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class RotateToPlayerStateLogic : StateLogic, IOnUpdateLogic
	{
		[SerializeField] private Transform m_model = null;
		[SerializeField] private TransformReferenceHost m_playerTransform = null;

		public void OnUpdate(float deltaTime, float timeScale)
		{
			var playerTransform = m_playerTransform.Instance;
			m_model.LookAt(playerTransform);
		}
	}
}