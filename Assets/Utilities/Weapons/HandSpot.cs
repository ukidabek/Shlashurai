using System;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public class HandSpot
    {
        public enum Hand
        {
            Left = 17,
            Right = 18
        }
            
        [SerializeField] private Hand _humanBone = Hand.Left;
        public HumanBodyBones HumanBone => (HumanBodyBones) _humanBone;

        [SerializeField] private Transform _slotTransform = null;
        public Transform SlotTransform => _slotTransform;
    }
}