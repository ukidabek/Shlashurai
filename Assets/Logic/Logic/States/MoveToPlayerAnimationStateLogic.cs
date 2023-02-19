using UnityEngine;
using UnityEngine.AI;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.Enemy.Logic
{
	public class MoveToPlayerAnimationStateLogic : StateLogic, IOnUpdateLogic
    {
		[SerializeField] private NavMeshAgent m_navMeshAgent = null;
        [SerializeField] private Animator m_animator = null;
        [SerializeField] private AnimatorParameterDefinition m_movementanimatorParameterDefinition = null;

		public void OnUpdate(float deltaTime, float timeScale)
		{
            var magnitude = m_navMeshAgent.velocity.magnitude;
            m_movementanimatorParameterDefinition.SetFloat(m_animator, magnitude);
        }
	}
}