using UnityEngine;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.Player.Logic
{	
	public class AttackAnimationHandlingStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic
	{

		[SerializeField] AttackStateLogicBase m_attackStateLogic = null;
		[SerializeField] private Animator m_animatior = null;
		[SerializeField] private AnimatorParameterDefinition m_attackTriggerParametrDefinition = null;

		public void OnUpdate(float deltaTime)
		{
			if(m_attackStateLogic.PerformingAttack == false) 
				return;

			m_attackTriggerParametrDefinition.SetTrigger(m_animatior);
		}
	}
}