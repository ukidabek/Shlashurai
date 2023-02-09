using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.Enemy.Logic
{
	public class RotateToPlayerStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic
	{
        [SerializeField] private Transform m_model = null;
		[SerializeField] private TransformReferenceHost m_playerTransform = null;

		public void OnUpdate(float deltaTime)
		{
			var playerTransform = m_playerTransform.Instance;
			m_model.LookAt(playerTransform);
		}
	}
}