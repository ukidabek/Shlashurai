using System;
using UnityEngine;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	public abstract class SpawnBase<PoolT, ObjectT, PoolHandlerT> : MonoBehaviour
		where PoolT : Pool<ObjectT>, new() 
		where ObjectT : UnityEngine.Object
		where PoolHandlerT : PoolHandler<PoolT, ObjectT>, new()
	{
		[SerializeField] protected PoolHandlerT[] m_objectToSpawn = Array.Empty<PoolHandlerT>();
	}
}