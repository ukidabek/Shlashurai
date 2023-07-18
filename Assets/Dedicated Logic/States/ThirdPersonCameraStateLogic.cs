using Shlashurai.Input;
using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class ThirdPersonCameraStateLogic : StateLogic, IOnUpdateLogic
	{
		[SerializeField, Inject("Camera")] private Transform m_camera = null;
		[SerializeField] private InputValues m_inputValues = null;
		[SerializeField] private Vector2 m_rotationSpeed = new Vector2(10f, 10f);
		[SerializeField] private float m_topClamp = 70.0f;
		[SerializeField] private float m_bottomClamp = -30.0f;

		private Vector2 m_input = Vector2.zero;
		private Vector3 m_newRotation = Vector3.zero;
		private float m_yaw = 0f;
		private float m_pitch = 0f;

		public override void Activate()
		{
			base.Activate();

			var eulerAngles = m_camera.eulerAngles;
			m_yaw = eulerAngles.y;
			m_pitch = eulerAngles.x;
		}

		public void OnUpdate(float deltaTime, float timeScale)
		{
			m_input = m_inputValues.Look;

			m_pitch += m_input.y * m_rotationSpeed.x * deltaTime * timeScale;
			m_yaw += m_input.x * m_rotationSpeed.y * deltaTime * timeScale;

			m_pitch = ClampAngle(m_pitch, m_bottomClamp, m_topClamp);

			m_newRotation.x = m_pitch;
			m_newRotation.y = m_yaw;
			m_camera.rotation = Quaternion.Euler(m_newRotation);
		}

		private float ClampAngle(float angle, float min, float max)
		{
			if (angle < -360f) angle += 360f;
			if (angle > 360f) angle -= 360f;
			return Mathf.Clamp(angle, min, max);
		}

		private void OnDrawGizmos()
		{
			var transform = this.transform;
			var position = transform.position;
			var forward = transform.forward * 3f;
			var rotation = Quaternion.Euler(m_topClamp, m_yaw, 0f);
			var direction = rotation * forward;
			Debug.DrawRay(position, direction, Color.yellow);
			rotation = Quaternion.Euler(m_bottomClamp, m_yaw, 0f);
			direction = rotation * forward;
			Debug.DrawRay(position, direction, Color.yellow);

			if (m_camera == null) return;
			Debug.DrawRay(m_camera.position, m_camera.forward, Color.red);
		}
	}
}