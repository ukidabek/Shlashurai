using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class MovementAnimationStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic
	{
		[SerializeField] private AnimatorParameterDefinition m_movementParameterDefinition = null;
		[SerializeField] private AnimatorParameterDefinition m_forwardMovementParameterDefinition = null;
		[SerializeField] private Animator m_animator = null;
		[SerializeField] private InputValues m_inputValues = null;

		private float m_forwardInput = 0f;
        private float m_inputMagnitude = 0f;

		public void OnUpdate(float deltaTime)
        {
			m_forwardInput = m_inputValues.Move.y;
			m_inputMagnitude = m_inputValues.Move.magnitude;
            m_movementParameterDefinition.SetFloat(m_animator, m_inputMagnitude);
			m_forwardMovementParameterDefinition.SetFloat(m_animator, m_forwardInput);
		}
	}
}