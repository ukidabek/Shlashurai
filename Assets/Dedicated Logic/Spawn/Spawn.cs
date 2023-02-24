using System.Linq;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Shlashurai.Spawn
{
	[Serializable]
	public class Spawn
	{
		[SerializeField] private GameObjectPoolHander m_handler = null;

		public GameObject ObjectToSpawn => m_handler.ObjectToSpawn;

		[SerializeField, Range(0f, 1f)] private float m_chance = 1.0f;
		public float Chance => m_chance;
		private Vector2 m_range = Vector2.zero;

		public void Initialize(float previousChance)
		{
			//base.Initialize(TODO);
			m_range.Set(previousChance, previousChance + m_chance);
		}

		public bool IsInRange(float roll) => m_range.x <= roll && m_range.y >= roll;
		public bool Roll() => UnityEngine.Random.Range(0f, 1f) <= m_chance;

		public static float Initialize(IEnumerable<Spawn> spawns)
		{
			var m_totalChance = spawns.Sum(x => x.Chance);
			var previousChance = 0f;
			foreach (var item in spawns)
			{
				item.Initialize(previousChance);
				previousChance = item.Chance;
			}

			return m_totalChance;
		}

		public static Spawn GetRandom(IEnumerable<Spawn> spawns, float roll) => spawns.FirstOrDefault(x => x.IsInRange(roll));
	}
}