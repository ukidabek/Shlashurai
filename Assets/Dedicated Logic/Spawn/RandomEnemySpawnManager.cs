using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Utilities.ReferenceHost;
using System.Collections;
using System;

namespace Shlashurai.Spawn
{
	public class RandomEnemySpawnManager : MonoBehaviour
	{
		[Serializable]
		public class Spawn
		{
			[SerializeField] private GameObjectPoolHander m_handler = null;

			public GameObject ObjectToSpawn => m_handler.ObjectToSpawn;

			[SerializeField] private float m_chance = 1.0f;
			public float Chance => m_chance;
			private Vector2 m_range = Vector2.zero;

			public void Initialize(float previousChance)
			{
				//base.Initialize(TODO);
				m_range.Set(previousChance, previousChance + m_chance);
			}

			public bool IsInRange(float roll) => m_range.x <= roll && m_range.y >= roll;

		}

		[SerializeField] private TransformReferenceHost m_playerTransform = null;
		[SerializeField] private GameObjectSpawn m_spawn = null;
		[SerializeField] private float m_spawnInterval = 5f;
		[SerializeField] private float m_spawnRange = 5f;
		[SerializeField] private Spawn[] m_enemyToSpawn = null;

		private NavMeshHit m_navMeshHit = new NavMeshHit();
		private float m_counter = 0f;
		private float m_totalChance = 0f;

		private void Awake()
		{
			m_totalChance = m_enemyToSpawn.Sum(x => x.Chance);
			var previousChance = 0f;
			foreach (var item in m_enemyToSpawn)
			{
				item.Initialize(previousChance);
				previousChance = item.Chance;
			}
		}

		private IEnumerator SpawnCoroutine(GameObject enemy)
		{
			var currentPlayerPosition = Vector3.zero;
			do
			{
				yield return null;

				currentPlayerPosition = m_playerTransform.Instance.position;
				var randomPointOnCircle = UnityEngine.Random.insideUnitCircle;
				randomPointOnCircle.Normalize();
				randomPointOnCircle *= m_spawnRange;

				currentPlayerPosition.x += randomPointOnCircle.x;
				currentPlayerPosition.z += randomPointOnCircle.y;
			}
			while (!NavMesh.SamplePosition(currentPlayerPosition, out m_navMeshHit, 1f, NavMesh.AllAreas));

			enemy.transform.position = m_navMeshHit.position;
			enemy.gameObject.SetActive(true);
		}

		private void Update()
		{
			if (m_counter <= 0f)
			{
				m_counter = m_spawnInterval;
				var roll = UnityEngine.Random.Range(0f, m_totalChance);

				var objectSpawner = m_enemyToSpawn.FirstOrDefault(x => x.IsInRange(roll));
				if (objectSpawner == null)
					return;

				var enemy = m_spawn.GetInstance(objectSpawner.ObjectToSpawn);
				var currentPlayerPosition = m_playerTransform.Instance.position;

				StartCoroutine(SpawnCoroutine(enemy));

				return;
			}

			m_counter -= Time.deltaTime;
		}
	}
}