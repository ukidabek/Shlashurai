﻿using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class MovementAnimationStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic
	{
		[SerializeField] private AnimatorParameterDefinition m_movementParameterDefinition = null;
		[SerializeField] private AnimatorParameterDefinition m_forwardMovementParameterDefinition = null;
		[SerializeField] private AnimatorParameterDefinition m_rightMovementParameterDefinition = null;
		[SerializeField] private Animator m_animator = null;
		[SerializeField] private InputValues m_inputValues = null;

		public void OnUpdate(float deltaTime)
        {
			var move = m_inputValues.Move;
            m_movementParameterDefinition.SetFloat(m_animator, move.magnitude);
			m_forwardMovementParameterDefinition.SetFloat(m_animator, move.y);
			m_rightMovementParameterDefinition.SetFloat(m_animator, move.x);
		}
	}
}