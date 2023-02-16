using UnityEngine;

namespace Utilities.Pool
{
	public abstract class PoolReturnerBase<T, PoolT, PoolElemenT> : MonoBehaviour where T : Object where PoolT : Pool<T, PoolElemenT> where PoolElemenT : class
	{
		protected T Component = default;
		public PoolT Pool { get; set; }

		protected virtual void Awake()
		{
			Component = GetComponent<T>();
		}

		protected abstract void OnDisable();
	}

	public abstract class PoolReturnerBase<T, PoolT> : PoolReturnerBase<T, PoolT, T> where T : Object where PoolT : Pool<T>
	{
		protected override void OnDisable()
		{
			Pool.Return(Component);
		}
	}
}