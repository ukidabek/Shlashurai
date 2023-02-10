using UnityEditor.Animations;
using UnityEngine;

namespace Utilities.General
{
    public class AnimatorDefinitionBase : ScriptableObject
    {
        [SerializeField, HideInInspector] protected AnimatorController _animator = null;
    }
}