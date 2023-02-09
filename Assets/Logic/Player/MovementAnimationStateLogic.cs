using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class MovementAnimationStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic
	{
		[SerializeField] private AnimatorParameterDefinition m_movementParameterDefinition = null;
        [SerializeField] private Animator m_animator = null;
		[SerializeField] private InputValues m_inputValues = null;

        private float m_input;

		public void OnUpdate(float deltaTime)
        {
			m_input = m_inputValues.Move.magnitude;
            m_movementParameterDefinition.SetFloat(m_animator, m_input);
		}
	}
}