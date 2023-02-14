using System;
using UnityEngine;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	[Serializable]
	public abstract class PoolHandler<PoolT, ObjectT> : MonoBehaviour where PoolT : Pool<ObjectT>, new() where ObjectT : UnityEngine.Object
	{
		[SerializeField] private ObjectT m_gameObjectToSpan = null;

		private PoolT m_gameObjectPool = default(PoolT);

		public virtual void Initialize(Transform parent, float previousChande)
		{
			m_gameObjectPool = new PoolT();
			m_gameObjectPool.Initialize(m_gameObjectToSpan, parent);
			m_gameObjectPool.OnPoolElementSelected = null;
		}


		public ObjectT SpawnObject() => m_gameObjectPool.Get();
	}
}