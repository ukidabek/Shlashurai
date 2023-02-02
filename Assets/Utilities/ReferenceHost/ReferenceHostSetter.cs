using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utilities.ReferenceHost
{
    public abstract class ReferenceHostSetter<T, T1> : MonoBehaviour where T : ReferenceHost<T1> where T1 : Object
    {
        private enum SetReferenceMode { Awake, Start, LateStart }
        
        [SerializeField] private T1 m_reference = null;
        [SerializeField] private T m_host;
        [SerializeField] private SetReferenceMode m_setMode = SetReferenceMode.Awake;

        private void Awake() => SetReference(SetReferenceMode.Awake);
        
        private IEnumerator Start()
        {
            SetReference(SetReferenceMode.Start);
            yield return null;
            SetReference(SetReferenceMode.LateStart);
        }

        private void SetReference(SetReferenceMode mode)
        {
            if (m_setMode == mode)
                m_host?.SetReference(m_reference);
        }
        
        private void Reset()
        {
            m_reference = GetComponent<T1>();
        }
    }
}