using System.Collections.Generic;

namespace Logic.Interactions
{
    public interface IInteractionSelector
    {
        IEnumerable<IInteractable> SelectedInteractions { get; }
        void Select(IEnumerable<IInteractable> interactables);
    }
}