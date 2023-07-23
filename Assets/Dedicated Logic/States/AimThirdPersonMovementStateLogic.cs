using Cinemachine;
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
		[SerializeField, Inject("Model")] private Transform m_model = null;
		[SerializeField, Inject("Camera")] private Transform m_camera = null;
		[SerializeField, Inject("AimVirtualCamera")] private CinemachineVirtualCamera m_aimVirtualCamera = null;
		[SerializeField, Inject("SkillSpawnPoint")] private Transform m_skillSpawnPoint = null;
		[SerializeField, Inject] private Rigidbody m_rigidbody = null;
		[SerializeField] private InputValues m_inputValues = null;
		[Header("Settings")]
		[SerializeField] private float m_speed = 4;
		[SerializeField] private float m_rotationSnapSpeed = 4;
		[SerializeField] private LayerMask m_layerMask;

		private Vector3 m_direction = Vector3.zero;
		private Quaternion m_rotation = Quaternion.identity;
		private Vector3 m_forward = Vector3.forward;
		private Vector3 m_right = Vector3.right;
		private Vector3 m_rayCastHitPosition = Vector3.zero;

		public void OnUpdate(float deltaTime, float timeScale)
		{
			var cameraEulerAngles = m_camera.transform.eulerAngles;
			var aimCameraTransform = m_aimVirtualCamera.transform;
			var aimCameraPosition = aimCameraTransform.position;
			var aimCameraForward = aimCameraTransform.forward;
			
			cameraEulerAngles.x = 0;

			Debug.DrawRay(aimCameraTransform.position, aimCameraTransform.forward * float.MaxValue, Color.red);
			if (Physics.Raycast(aimCameraTransform.position, aimCameraTransform.forward, out var hitInfo, float.PositiveInfinity, m_layerMask))
			{
				Debug.DrawLine(aimCameraTransform.position, hitInfo.point, Color.green);
				m_rayCastHitPosition = hitInfo.point;
			}
			else
				m_rayCastHitPosition = aimCameraPosition + (aimCameraForward * 100f);

			m_skillSpawnPoint.LookAt(m_rayCastHitPosition);

			m_rayCastHitPosition.y = m_model.transform.position.y;
			var direction = m_rayCastHitPosition - m_model.transform.position;
			direction.Normalize();
			m_rotation = Quaternion.LookRotation(direction);
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