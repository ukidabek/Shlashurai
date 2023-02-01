using UnityEditor.Animations;
using UnityEngine;

namespace Utilities.General
{
    public class AnimatorDefinitionBase : ScriptableObject
    {
        [SerializeField] protected AnimatorController _animator = null;
    }
}