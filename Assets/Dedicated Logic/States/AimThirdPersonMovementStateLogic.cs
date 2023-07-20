using Shlashurai.Input;
using Unity.Mathematics;
using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class AimThirdPersonMovementStateLogic : StateLogic, IOnUpdateLogic, IOnFixUpdateLogic
	{
		[Header("References")]
		[SerializeField, Inject("Root")] private Transform m_root = null;
		[SerializeField, Inject("Model")] private Transform m_model = null;
		[SerializeField, Inject("Camera")] private Transform m_camera = null;
		[SerializeField, Inject] private Rigidbody m_rigidbody = null;
		[SerializeField] private InputValues m_inputValues = null;
		[Header("Settings")]
		[SerializeField] private float m_speed = 4;
		[SerializeField] private float m_rotationSnapSpeed = 4;

		private Vector3 m_direction = Vector3.zero;
		private Quaternion m_rotation = Quaternion.identity;
		private Vector3 m_forward = Vector3.forward;
		private Vector3 m_right = Vector3.right;

		public void OnUpdate(float deltaTime, float timeScale)
		{
			var cameraEulerAngles = m_camera.transform.eulerAngles;
			cameraEulerAngles.x = 0;
			m_rotation = Quaternion.Euler(cameraEulerAngles);

			m_model.rotation = Quaternion.RotateTowards(m_model.rotation, m_rotation, m_rotationSnapSpeed * timeScale);

			var forward = (m_rotation * m_forward) * m_inputValues.Move.y;
			var right = (m_rotation * m_right) * m_inputValues.Move.x;
			m_direction = forward + right;
		}
		
		public void OnFixUpdate(float deltaTime, float timeScale)
		{
 			var m_newPosition = m_rigidbody.position + (m_direction * (m_speed * deltaTime * timeScale));
			m_rigidbody.MovePosition(m_newPosition);
		}
	}
}