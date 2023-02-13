using UnityEngine;

namespace Utilities.UI
{
    public abstract class ManagerModelSetterBase<T, T1> : MonoBehaviour
        where T : MonoBehaviour
        where T1 : ManagerModelBase<T>
    {
        [SerializeField] private T _manager = null;
        [SerializeField] private T1 _managerModel = null;

        protected virtual void Awake()
        {
            _managerModel.Initialize(_manager);
        }
    }
}