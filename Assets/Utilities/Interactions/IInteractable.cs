namespace Logic.Interactions
{
    public interface IInteractable
    {
        bool AutoInteraction { get; }
        bool Interactable { get; }
        void Interact(UnityEngine.Object user);
        void OnSelected();
        void OnDeselected();
    }
}