using UnityEngine;
using Object = UnityEngine.Object;

namespace Utilities.ReferenceHost
{
    public abstract class ReferenceHost<T> : ScriptableObject where T : Object
    {
        [SerializeField] private T m_instance = null;
        public T Instance => m_instance;

        internal void SetReference(T reference) => m_instance = reference;
    }
}