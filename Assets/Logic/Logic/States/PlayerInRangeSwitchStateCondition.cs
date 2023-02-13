using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.Enemy.Logic
{
    public class PlayerInRangeSwitchStateCondition : SwitchStateConditionBase
    {
        [SerializeField] private Transform m_root = null;
        [SerializeField] public TransformReferenceHost m_playerTransform = null;
        [SerializeField] private float m_distance = 0.5f;

        public override bool Condition => IsInRange();

        private bool IsInRange()
        {
            var playerTransform = m_playerTransform.Instance;
            var distance = Vector3.Distance(playerTransform.position, m_root.position);
            return distance <= m_distance;
        }
    }
}