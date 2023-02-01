using System.Collections.Generic;
using UnityEngine;

namespace Logic.Interactions
{
    public abstract class InteractionSelectorBase : MonoBehaviour, IInteractionSelector
    {
        public abstract IEnumerable<IInteractable> SelectedInteractions { get; }
        public abstract void Select(IEnumerable<IInteractable> interactables);
    }
}