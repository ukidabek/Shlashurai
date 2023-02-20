using System;
using UnityEngine;

namespace Shlashurai.Logic
{
    public class OnCollisionEnterHandler : MonoBehaviour
    {
        public event Action<Collision> OnControllerColliderHitCallback = null;
        private void OnCollisionEnter(Collision collision) => OnControllerColliderHitCallback?.Invoke(collision);
    }
}