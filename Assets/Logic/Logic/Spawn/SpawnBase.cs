using System;
using UnityEngine;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	public abstract class SpawnBase<PoolT, ObjectT, PoolHandlerT> : SpawnBase<PoolT, ObjectT, ObjectT, PoolHandlerT>
		where PoolT : Pool<ObjectT>, new()
		where ObjectT : UnityEngine.Object
		where PoolHandlerT : PoolHandler<PoolT, ObjectT>, new()
	{
	}

	public abstract class SpawnBase<PoolT, ObjectT, PoolElementT, PoolHandlerT> : MonoBehaviour
		where PoolT : Pool<ObjectT, PoolElementT>, new() 
		where ObjectT : UnityEngine.Object
		where PoolHandlerT : PoolHandler<PoolT, ObjectT, PoolElementT>, new()
	{
		[SerializeField] protected PoolHandlerT[] m_poolHandlers = Array.Empty<PoolHandlerT>();

		protected virtual void Start()
		{
			foreach (var item in m_poolHandlers)
			{
				item.Initialize();
			}
		}
	}
}