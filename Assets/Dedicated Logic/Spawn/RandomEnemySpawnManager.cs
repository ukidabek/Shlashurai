using UnityEngine;
using UnityEngine.AI;
using Utilities.ReferenceHost;
using System.Collections;

namespace Shlashurai.Spawn
{

	public class RandomEnemySpawnManager : MonoBehaviour
	{

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
			m_totalChance = Spawn.Initialize(m_enemyToSpawn);
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

				var objectSpawner = Spawn.GetRandom(m_enemyToSpawn, roll);
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