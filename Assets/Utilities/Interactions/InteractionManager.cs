using System.Linq;

namespace Logic.Interactions
{
    public class InteractionManager
    {
        private readonly IInteractionSelector _interactionSelector = null;
        
        private readonly UnityEngine.Object _user = null;

        public InteractionManager(IInteractionSelector interactionSelector, UnityEngine.Object user)
        {
            _interactionSelector = interactionSelector;
            _user = user;
        }

        public void ManualInteract() => HandleInteraction(false);

        private void HandleInteraction(bool auto)
        {
            if (_interactionSelector.SelectedInteractions.Any())
            {
                var manualInteractions = _interactionSelector.SelectedInteractions
                    .Where(interactable => interactable.Interactable && interactable.AutoInteraction == auto);
                foreach (var detectedPickUp in manualInteractions)
                    detectedPickUp.Interact(_user);
            }
        }

        public void AutoInteract() => HandleInteraction(true);
    }
}