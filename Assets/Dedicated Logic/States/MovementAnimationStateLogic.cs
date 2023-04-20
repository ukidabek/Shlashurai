using Shlashurai.Input;
using UnityEngine;
using Utilities.General;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class MovementAnimationStateLogic : StateLogic, IOnUpdateLogic
	{
		[SerializeField, Inject] private Animator m_animator = null;
		[SerializeField] private AnimatorParameterDefinition m_movementParameterDefinition = null;
		[SerializeField] private AnimatorParameterDefinition m_forwardMovementParameterDefinition = null;
		[SerializeField] private AnimatorParameterDefinition m_rightMovementParameterDefinition = null;
		[SerializeField] private InputValues m_inputValues = null;

		public void OnUpdate(float deltaTime, float timeScale)
		{
			var move = m_inputValues.Move;
			m_movementParameterDefinition.SetFloat(m_animator, move.magnitude);
			m_forwardMovementParameterDefinition.SetFloat(m_animator, move.y);
			m_rightMovementParameterDefinition.SetFloat(m_animator, move.x);
		}
	}
}