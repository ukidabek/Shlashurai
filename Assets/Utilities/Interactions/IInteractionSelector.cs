using System.Collections.Generic;

namespace Utilities.Interactions
{
    public interface IInteractionSelector
    {
        IEnumerable<IInteractable> SelectedInteractions { get; }
        void Select(IEnumerable<IInteractable> interactables);
    }
}