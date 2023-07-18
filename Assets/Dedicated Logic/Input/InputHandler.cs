using UnityEngine;
using UnityEngine.InputSystem;

namespace Shlashurai.Input
{
	public class InputHandler : MonoBehaviour
	{
		[SerializeField] private PlayerInput m_playerInput = null;
		[SerializeField] private InputValues m_values = null;
		[SerializeField] private string m_keyboardAndMouseControlSchemeName = "Keyboard&Mouse";

		private Vector2 m_center = Vector2.zero;

		public void OnMove(InputValue value) => m_values.Move = value.Get<Vector2>();

		public void OnLook(InputValue value)
		{
			var input = value.Get<Vector2>();
			if (m_playerInput.currentControlScheme == m_keyboardAndMouseControlSchemeName)
			{
				m_center.Set(Screen.width / 2, Screen.height / 2);
				input -= m_center;
				input.Normalize();
			}

			m_values.Look = input;
		}

		public void OnSlash(InputValue value) => m_values.Slash = value.isPressed;
 		public void OnAttack(InputValue value) => m_values.Attack = value.isPressed;
		public void OnAim(InputValue value) => m_values.Aim = value.isPressed;
		public void OnCast1(InputValue value) => m_values.Cast1 = value.isPressed;
		public void OnCast2(InputValue value) => m_values.Cast2 = value.isPressed;
		public void OnPause(InputValue value) => m_values.Pause = value.isPressed;
		public void OnInventory(InputValue value) => m_values.Inventory = value.isPressed;
	}
}