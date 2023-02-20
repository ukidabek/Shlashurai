#if UNITY_EDITOR
using UnityEditor.Animations;
#endif

using UnityEngine;

namespace Utilities.General
{
    public class AnimatorDefinitionBase : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField, HideInInspector] protected AnimatorController _animator = null;
#endif
    }
}