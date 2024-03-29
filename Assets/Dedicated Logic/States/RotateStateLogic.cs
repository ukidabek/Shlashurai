using Shlashurai.Input;
using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class RotateStateLogic : StateLogic, IOnUpdateLogic
	{
		[SerializeField, Inject("Model")] private Transform m_root = null;
		[SerializeField] private InputValues m_inputValues = null;
		[SerializeField] private float m_speed = 10;

		private Vector3 up = Vector3.up;
		private Vector3 direction = Vector3.zero;
		private readonly Vector3 zero = Vector3.zero;

		public void OnUpdate(float deltaTime, float timeScale)
		{
			var look = m_inputValues.Look;
			direction.Set(look.x, 0, look.y);
			if (direction == zero) return;
			var rotation = Quaternion.LookRotation(direction, up);
			var speed = m_speed * timeScale;
			m_root.rotation = Quaternion.RotateTowards(m_root.rotation, rotation, speed);
		}
	}
}