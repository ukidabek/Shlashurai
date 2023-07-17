using Shlashurai.Input;
using UnityEngine;
using Utilities.General;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class SimpleMovementAnimationStateLogic : StateLogic, IOnUpdateLogic
	{
		[SerializeField, Inject] private Animator m_animator = null;
		[SerializeField] private AnimatorParameterDefinition m_movementParameterDefinition = null;
		[SerializeField] private AnimatorParameterDefinition m_forwardMovementParameterDefinition = null;
		[SerializeField] private InputValues m_inputValues = null;

		public void OnUpdate(float deltaTime, float timeScale)
		{
			var magnitude = m_inputValues.Move.magnitude;
			m_movementParameterDefinition.SetFloat(m_animator, magnitude);
			m_forwardMovementParameterDefinition.SetFloat(m_animator, magnitude);
		}
	}
}