using UnityEngine;

namespace Logic.Events
{
    public abstract class EventHandlerBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T m_eventsDestination = null;
        protected  void OnEnable()=>Subscribe();
        protected  void OnDisable() => Unsubscribe();
        protected  void OnDestroy() => Unsubscribe();

        protected abstract void Subscribe();
        protected abstract void Unsubscribe();
        
        private void Reset()
        {
            m_eventsDestination = GetComponent<T>();
        }
    }
}