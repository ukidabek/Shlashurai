using UnityEngine;
using Utilities.General;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.Player.Logic
{	
	public class AttackAnimationHandlingStateLogic : StateLogic, IOnUpdateLogic
	{

		[SerializeField] AttackStateLogic m_attackStateLogic = null;
		[SerializeField, Inject] private Animator m_animatior = null;
		[SerializeField] private AnimatorParameterDefinition m_attackTriggerParametrDefinition = null;

		public void OnUpdate(float deltaTime, float timeScale)
		{
			if(m_attackStateLogic.PerformingAttack == false) 
				return;

			m_attackTriggerParametrDefinition.SetTrigger(m_animatior);
		}
	}
}