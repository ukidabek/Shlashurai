using System;
using UnityEngine;

namespace Shlashurai.Player.Logic
{
    public class OnControllerColliderHitHandler : MonoBehaviour
    {
        public event Action<ControllerColliderHit> OnControllerColliderHitCallback = null;
        private void OnControllerColliderHit(ControllerColliderHit hit) => OnControllerColliderHitCallback?.Invoke(hit);
    }
}