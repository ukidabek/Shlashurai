using Shlashurai.Items;
using System;
using System.Linq;
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

	public abstract class SpawnBase<PoolT, ObjectToSpawnT, PoolElementT, PoolHandlerT> : SpawnBase
		where PoolT : Pool<ObjectToSpawnT, PoolElementT>, new() 
		where ObjectToSpawnT : UnityEngine.Object
		where PoolHandlerT : PoolHandler<PoolT, ObjectToSpawnT, PoolElementT>, new()
	{
		[SerializeField] protected PoolHandlerT[] m_poolHandlers = Array.Empty<PoolHandlerT>();

		protected GameObject SpawnHost { get; set; } = null;

		public PoolElementT GetItemInstance(ObjectToSpawnT item)
		{
			var poolHandler = m_poolHandlers.FirstOrDefault(handler => handler.ObjectToSpawn == item);
			if (poolHandler == null)
				return default;

			return poolHandler.SpawnObject();
		}

		public override void Initialize()
		{
			SpawnHost = new GameObject(name);
			var spawnHostTransform = SpawnHost.transform;
			foreach (var item in m_poolHandlers)
				item.Initialize(spawnHostTransform);
		}
	}

	public abstract class SpawnBase : ScriptableObject
	{
		public abstract void Initialize();
	}
}