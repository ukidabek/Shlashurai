using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

namespace Logic.Interactions
{
    public class InteractionDetector : InteractionDetectorBase
    {
        [SerializeField] private float radius = 3f;
        [SerializeField] private LayerMask _layerMask;

        private readonly IInteractable[] _empty = Array.Empty<IInteractable>();
        private readonly Collider[] _collidersBuffer = new Collider[100];
        private int _count = 0;
        private IEnumerable<Collider> _colliders = null;
        
        private void Awake()
        {
            _colliders = GetColliders();
        }

        private void Update()
        {
            _count = Physics.OverlapSphereNonAlloc(transform.position, radius,_collidersBuffer, _layerMask);
            if (_count == 0)
            {
                InvokeOnInteractionDetected(_empty);
                Profiler.EndSample();
                return;
            }
            
            var intractables = _colliders
                .Select(collider => collider.gameObject.GetComponent<IInteractable>());
            
            InvokeOnInteractionDetected(intractables);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public IEnumerable<Collider> GetColliders()
        {
            for (int i = 0; i < _count; i++)
                yield return _collidersBuffer[i];
        }
    }
}