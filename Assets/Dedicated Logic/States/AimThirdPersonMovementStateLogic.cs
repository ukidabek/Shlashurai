using Shlashurai.Input;
using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class AimThirdPersonMovementStateLogic : StateLogic, IOnUpdateLogic, IOnFixUpdateLogic
	{
		[Header("References")]
		[SerializeField, Inject("Root")] private Transform m_root = null;
		[SerializeField, Inject] private Rigidbody m_rigidbody = null;
		[SerializeField] private InputValues m_inputValues = null;
		[Header("Settings")]
		[SerializeField] private float m_speed = 4;

		public void OnUpdate(float deltaTime, float timeScale)
		{
		}
		
		public void OnFixUpdate(float deltaTime, float timeScale)
		{
		}
	}
}