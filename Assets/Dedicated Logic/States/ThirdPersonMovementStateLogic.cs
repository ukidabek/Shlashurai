using Shlashurai.Input;
using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class ThirdPersonMovementStateLogic : StateLogic, IOnUpdateLogic, IOnFixUpdateLogic
	{
		[Header("References")]
		[SerializeField, Inject("Root")] private Transform m_root = null;
		[SerializeField, Inject("Model")] private Transform m_model = null;
		[SerializeField, Inject("Camera")] private Transform m_camera = null;
		[SerializeField, Inject] private Rigidbody m_rigidbody = null;
		[SerializeField] private InputValues m_inputValues = null;
		[Header("Settings")]
		[SerializeField] private float m_speed = 4;

		private Vector3 m_input = Vector3.zero;
		private Vector3 m_newPosition = Vector3.zero;
		private Vector3 m_targetDirection = Vector3.zero;
		private Quaternion m_rotation = Quaternion.identity;
		private float m_targetRotation = 0f;
		private float m_targetSpeed = 0f;

		private readonly Vector3 m_vectorZero = Vector3.zero;
		private readonly Vector3 m_vectorForward = Vector3.forward;

		public void OnUpdate(float deltaTime, float timeScale)
		{
			var moveVector = m_inputValues.Move;
			m_input.Set(moveVector.x, 0f, moveVector.y);
			m_input.Normalize();

			m_targetSpeed = m_speed * m_input.magnitude;

			if (m_input != m_vectorZero)
			{
				var angleFormInput = Mathf.Atan2(m_input.x, m_input.z) * Mathf.Rad2Deg;
				m_targetRotation = angleFormInput + m_camera.eulerAngles.y;
			}

			m_rotation = Quaternion.Euler(0.0f, m_targetRotation, 0.0f);
			m_model.rotation = m_rotation;
			m_targetDirection = m_rotation * m_vectorForward;
		}

		public void OnFixUpdate(float deltaTime, float timeScale)
		{
			m_newPosition = m_rigidbody.position + m_targetDirection * (m_targetSpeed * deltaTime * timeScale);
			m_rigidbody.MovePosition(m_newPosition);
		}
	}
}