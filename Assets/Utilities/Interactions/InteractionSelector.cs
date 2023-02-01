using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Logic.Interactions
{
    public class InteractionSelector : InteractionSelectorBase
    {
        [SerializeField] private List<InteractionDetectorBase> _detectors = null;
        
        [SerializeField] private List<MonoBehaviour> _componentsList = new List<MonoBehaviour>();
        [SerializeField] private UnityEvent<GameObject> _interactionSelected = new UnityEvent<GameObject>();

        private readonly List<IInteractable> _selectedIntractables = new List<IInteractable>();
        public override IEnumerable<IInteractable> SelectedInteractions => _selectedIntractables;

        private void Start()
        {
            foreach (var interactionDetectorBase in _detectors)
                interactionDetectorBase.OnDetectionStatusChanged += Select;
        }

        private void OnDestroy()
        {
            foreach (var interactionDetectorBase in _detectors)
                interactionDetectorBase.OnDetectionStatusChanged += Select;
        }

        public override void Select(IEnumerable<IInteractable> interactables)
        {
            _componentsList.Clear();
            _componentsList.AddRange(interactables.OfType<MonoBehaviour>());

            _selectedIntractables.Clear();
            var selectedInteraction = _componentsList.FirstOrDefault();
            if (selectedInteraction != null)
            {
                _interactionSelected.Invoke(selectedInteraction.gameObject);
                _selectedIntractables.Add(selectedInteraction as IInteractable);
            }
            else
                _interactionSelected.Invoke(null);
        }
    }
}