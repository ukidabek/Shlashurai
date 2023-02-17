using System;
using UnityEngine;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	public abstract class PoolHandler<PoolT, ObjectT> : PoolHandler<PoolT, ObjectT, ObjectT>
		where PoolT : Pool<ObjectT>, new()
		where ObjectT : UnityEngine.Object
	{
		public override void Initialize(Transform parent)
		{
			base.Initialize(parent);
			m_pool = new PoolT();
			m_pool.Initialize(m_objectToSpan, m_poolTransform);
			m_pool.OnPoolElementSelected = null;
		}
	}

	public abstract class PoolHandler<PoolT, PoolObjectT, PoolElementT> : ScriptableObject 
		where PoolT : Pool<PoolObjectT, PoolElementT>, new() 
		where PoolObjectT : UnityEngine.Object
	{
		protected Transform m_poolTransform = null; 
		[SerializeField] protected PoolObjectT m_objectToSpan = null;
		public PoolObjectT ObjectToSpawn => m_objectToSpan;

		protected PoolT m_pool = default(PoolT);

		public virtual void Initialize(Transform parent)
		{
			m_poolTransform = new GameObject(ObjectToSpawn.name).transform;
			m_poolTransform.SetParent(parent, false);
		}

		public virtual PoolElementT SpawnObject() => m_pool.Get();
	}
}