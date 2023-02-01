using System;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public class HandSlotBinding
    {
        [SerializeField] private HumanBodyBones _humanBone = HumanBodyBones.LeftHand;
        public HumanBodyBones HumanBone => _humanBone;

        [SerializeField] private TransformFollower _transformFollower = null;

        public void SetTransform(Transform transform)
        {
            _transformFollower.SourceTransform = transform;
        }
    }
}