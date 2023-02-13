using System;
using UnityEngine;

namespace Utilities.UI
{
    public abstract class ManagerModelViewBase<ManagerType, ManagerModelType> : MonoBehaviour
        where ManagerType : MonoBehaviour
        where ManagerModelType : ManagerModelBase<ManagerType>
    {
        [SerializeField] protected ManagerModelType _managerModel = null;

        public ManagerType Manager => _managerModel.ManagerInstance;

        private void Enable(bool status)
        {
            if(gameObject.activeSelf == status)
                return;
            
            gameObject.SetActive(status);
        }
        
        protected virtual void Awake()
        {
            gameObject.SetActive(false);
            if (_managerModel != null)
                _managerModel.OnShowUI.AddListener(Enable);
        }

        protected virtual void OnDestroy()
        {
            if (_managerModel != null)
                _managerModel.OnShowUI.RemoveListener(Enable);
        }
    }
}