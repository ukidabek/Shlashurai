using UnityEngine;
using UnityEngine.Events;

namespace Utilities.UI
{
    public abstract class ManagerModelBase<T> : ScriptableObject where T : MonoBehaviour
    {
        public UnityEvent<bool> OnShowUI = new UnityEvent<bool>();
        
        [SerializeField] private T _managerInstance = null;
        public T ManagerInstance => _managerInstance;

        public virtual void Initialize(T weaponManager)
        {
            _managerInstance = weaponManager;
        }

        public void ShowUI(bool status) => OnShowUI.Invoke(status);
    }
}