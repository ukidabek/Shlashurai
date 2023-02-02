using UnityEngine;

namespace Utilities.ObjectGroups
{
    public abstract class ObjectGroupWorker : MonoBehaviour
    {
        [SerializeField] protected ObjectGroup m_objectGroup = null;

        protected abstract void Awake();
    }
}