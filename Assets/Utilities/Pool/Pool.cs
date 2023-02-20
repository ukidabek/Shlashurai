using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Utilities.Pool
{
	public class Pool<T> : Pool<T, T> where T : UnityEngine.Object
	{
		public Pool() { }

		public Pool(T prefab, Transform parent = null, int initialCount = 5) : base(prefab, parent, initialCount) { }
	}

	[Serializable]
    public class Pool<PrefabT, PoolElementT> where PrefabT : UnityEngine.Object
    {
		[SerializeField] protected PrefabT m_prefab = null;
        [SerializeField] protected Transform m_parent = null;
    
        protected List<PoolElementT> m_poolElements = new List<PoolElementT>();
    
        public Func<PoolElementT, bool> ValidateIfPoolElementInactive = null;
        public Func<PrefabT, Transform, PoolElementT> CreatePoolElement = null;
        public Action<PoolElementT> DisablePoolElement = null;
    
        
        public Action<PoolElementT> OnPoolElementSelected = null;
        public Action<PoolElementT> OnPoolElementCreated = null;
        public Action<PoolElementT> OnPoolElementDisabled = null;
    
        protected IEnumerable<PoolElementT> m_activeObject = null;
        public IEnumerable<PoolElementT> ActiveObject => m_activeObject; 
    
        public Pool()
        {
		}

		public Pool(PrefabT prefab, Transform parent = null, int initialCount = 5) : this()
        {
            Initialize(prefab, parent, initialCount);
		}

		public virtual void Initialize(PrefabT prefab, Transform parent = null, int initialCount = 5)
		{
			Assert.IsNotNull(prefab);
			Assert.IsNotNull(ValidateIfPoolElementInactive);
			Assert.IsNotNull(CreatePoolElement);
			Assert.IsNotNull(DisablePoolElement);

			m_prefab = prefab;
			m_parent = parent;

			for (int i = 0; i < initialCount; i++)
				CreateNewInstance();

			m_activeObject = m_poolElements.Where(component => !ValidateIfPoolElementInactive(component));
		}

		private PoolElementT CreateNewInstance()
        {
			PoolElementT instance = CreatePoolElement(m_prefab, m_parent);
            OnPoolElementCreated?.Invoke(instance);
			m_poolElements.Add(instance);
            return instance;
        }
    
        public PoolElementT Get()
        {
			PoolElementT poolElement = default;
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
    
        public void Return(PoolElementT poolElement)
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

		protected PrefabT CreateInstanceFormPrefab(PrefabT prefab, Transform parent) => GameObject.Instantiate(prefab, parent, false);
	}
}