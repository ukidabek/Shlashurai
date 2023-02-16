using UnityEngine;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	public class RandomPoolHandler : PoolHandler<GameObjectPool, GameObject> 
	{
		[SerializeField] private float m_chance = 1.0f;
		public float Chance => m_chance;
		private Vector2 m_range = Vector2.zero;

		public void Initialize(float previousChande)
		{
			base.Initialize();
			m_range.Set(previousChande, previousChande + m_chance);
		}

		public bool IsInRange(float roll) => m_range.x <= roll && m_range.y >= roll;
	}
}