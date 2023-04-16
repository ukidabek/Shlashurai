using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class PlayerMovementStateLogic : StateLogic, IOnUpdateLogic, IOnFixUpdateLogic
	{
		[SerializeField, Inject("Root")] private Transform m_root = null;
		[SerializeField, Inject("Model")] private Transform m_model = null;
		[SerializeField] private InputValues m_inputValues = null;
		[SerializeField, Inject] private Rigidbody m_rigidbody = null;
		[SerializeField] private float m_speed = 4;
        public float Speed 
		{ 
			get => m_speed; 
			set => m_speed = value; 
		}

        [SerializeField] private bool m_freezeDirections = false;
		[SerializeField, Range(0, 1f)] float m_slerpOverRange = 1f;

		private Vector3 m_frizzedForwardDirection, 
			m_frizzedRightDirection, 
			m_input, 
			m_normalInput, 
			m_reflectedInput;

		public override void Activate()
		{
			base.Activate();

			m_frizzedForwardDirection = m_root.forward;
			m_frizzedRightDirection = m_root.right;
		}

		public void OnUpdate(float deltaTime, float timeScale)
		{
			var move = m_inputValues.Move;

			m_normalInput.Set(move.x, 0, move.y);
			m_normalInput.Normalize();
			m_reflectedInput = Vector3.Reflect(m_normalInput, m_root.right);

			var rootForward = m_root.forward;
			var dot = Vector3.Dot(m_root.forward, m_model.forward);

			var slerpValue = Mathf.InverseLerp(m_slerpOverRange, -m_slerpOverRange, dot);
			m_input = Vector3.Slerp(m_normalInput, m_reflectedInput, slerpValue);

#if UNITY_EDITOR
			var position = m_root.position;
			Debug.DrawRay(position, m_normalInput, Color.gray);
			Debug.DrawRay(position, m_input, Color.red);
			Debug.DrawRay(position, m_reflectedInput, Color.black);
#endif
		}

		public void OnFixUpdate(float deltaTime, float timeScale)
		{
			var forward = m_freezeDirections ? m_frizzedForwardDirection : m_model.forward;
			var right = m_freezeDirections ? m_frizzedRightDirection : m_model.right;

#if UNITY_EDITOR
			var position = m_root.position;
			Debug.DrawRay(position, forward, Color.blue);
			Debug.DrawRay(position, right, Color.red);
#endif

			forward *= m_speed * m_input.z * deltaTime * timeScale;
			right *= m_speed * m_input.x * deltaTime * timeScale;

			var velocity = m_rigidbody.position + (forward + right);
			m_rigidbody.MovePosition(velocity);

#if UNITY_EDITOR
			Debug.DrawRay(position, velocity, Color.cyan);
			Debug.DrawRay(position, m_rigidbody.velocity, Color.yellow);
#endif
		}
	}
}