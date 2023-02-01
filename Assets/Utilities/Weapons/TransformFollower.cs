using UnityEngine;

namespace Weapons
{
   public class TransformFollower : MonoBehaviour
   {
      [SerializeField] private Transform _sourceTransform = null;
      public Transform SourceTransform
      {
         get => _sourceTransform;
         set
         {
            _sourceTransform = value;
            enabled = _sourceTransform != null;
         }
      }

      private void Awake()
      {
         enabled = false;
      }

      private void Update()
      {
         transform.position = _sourceTransform.position;
         transform.rotation = _sourceTransform.rotation;
      }
   }
}
