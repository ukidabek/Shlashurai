using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.Interactions
{
    public abstract class InteractionDetectorBase : MonoBehaviour
    {
        public event Action<IEnumerable<IInteractable>> OnDetectionStatusChanged;
        
        protected void InvokeOnInteractionDetected(IEnumerable<IInteractable> interactable)
            => OnDetectionStatusChanged?.Invoke(interactable);
    }
}