using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities.Pool
{
	public class PoolReturnerBase<T, PoolT> : MonoBehaviour where T : UnityEngine.Object where PoolT : Pool<T>
	{
		private T Component = default;
		public PoolT Pool { get; set; }

		private void Awake()
		{
			Component = GetComponent<T>();
		}

		private void OnDisable()
		{
			Pool.Return(Component);
		}
	}

	[Serializable]
    public class Pool<T> where T : UnityEngine.Object
    {

		[SerializeField] protected T m_prefab = null;
        [SerializeField] protected Transform m_parent = null;
    
        protected List<T> m_poolElements = new List<T>();
    
        public Func<T, bool> ValidateIfPoolElementInactive = null;
        public Func<T, Transform, T> CreatePoolElement = null;
        public Action<T> DisablePoolElement = null;
    
        
        public Action<T> OnPoolElementSelected = null;
        public Action<T> OnPoolElementCreated = null;
        public Action<T> OnPoolElementDisabled = null;
    
        protected IEnumerable<T> m_activeObject = null;
        public IEnumerable<T> ActiveObject => m_activeObject; 
    
        public Pool()
        {
        }
    
        public Pool(T prefab, Transform parent = null, int initialCount = 5) : this()
        {
            Initialize(prefab, parent, initialCount);
        }

		public virtual void Initialize(T prefab, Transform parent = null, int initialCount = 5)
		{
			m_prefab = prefab;
			m_parent = parent;

			for (int i = 0; i < initialCount; i++)
				CreateNewInstance();

			m_activeObject = m_poolElements.Where(component => !ValidateIfPoolElementInactive(component));
		}

		private T CreateNewInstance()
        {
            T instance = CreatePoolElement(m_prefab, m_parent);
            OnPoolElementCreated?.Invoke(instance);
			m_poolElements.Add(instance);
            return instance;
        }
    
        public T Get()
        {
            T poolElement = null;
            for (int i = 0; i < m_poolElements.Count; i++)
            {
                if (ValidateIfPoolElementInactive(m_poolElements[i]))
                {
                    poolElement = m_poolElements[i];
                    m_poolElements.RemoveAt(i);
                    m_poolElements.Add(poolElement);
                    break;
                }
            }
    
            poolElement = poolElement == null ? CreateNewInstance() : poolElement;
            OnPoolElementSelected?.Invoke(poolElement);
            return poolElement;
        }
    
        public void Return(T poolElement)
        {
            if (!m_poolElements.Contains(poolElement)) return;
            
            DisablePoolElement(poolElement);
            OnPoolElementDisabled?.Invoke(poolElement);
        }
    
        public void DeactivateAllObjects()
        {
            foreach (var poolElement in m_poolElements)
            {
                DisablePoolElement(poolElement);
                OnPoolElementDisabled?.Invoke(poolElement);
            }
        }

		protected T CreateGameObjectInstanceFormPrefab(T prefab, Transform parent) => GameObject.Instantiate(prefab, parent, false);

	}
}