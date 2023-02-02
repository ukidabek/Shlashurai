using UnityEngine;
using UnityEngine.AI;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.Enemy.Logic
{
    public class MoveToPlayerStateLogicMonoBehaviour : StateLogicMonoBehaviour, IOnUpdateLogic
    {
        [SerializeField] public TransformReferenceHost m_playerTransform = null;
        [SerializeField] public NavMeshAgent m_navMeshAgent = null;
        
        public void OnUpdate(float deltaTime)
        {
            var player = m_playerTransform.Instance;
            m_navMeshAgent.destination = player.position;
        }
    }
}