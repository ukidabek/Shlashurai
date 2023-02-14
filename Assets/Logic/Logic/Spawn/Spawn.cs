using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Utilities.ReferenceHost;
using System.Collections;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	public class Spawn : SpawnBase<GameObjectPool, GameObject, RandomPoolHandler>
	{

		[SerializeField] private TransformReferenceHost m_playerTransform = null;
		[SerializeField] private float m_spawnInterval = 5f;
		[SerializeField] private float m_spawnRange = 5f;

		private float m_totalChande = 0f;
		private float m_counter = 0f;
		private NavMeshHit m_navMehsHit = new NavMeshHit();

		private void Awake()
		{
			m_totalChande = m_objectToSpawn.Sum(x => x.Chance);
			var previousChande = 0f;
			foreach (var item in m_objectToSpawn)
			{
				item.Initialize(transform, previousChande);
				previousChande = item.Chance;
			}
		}

		private float GetRandomValue() => UnityEngine.Random.Range(0f, m_totalChande);

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
			while (!NavMesh.SamplePosition(currentPlayerPosition, out m_navMehsHit, 1f, NavMesh.AllAreas));

			enemy.transform.position = m_navMehsHit.position;
			enemy.gameObject.SetActive(true);
		}

		private void Update()
		{
			if (m_counter <= 0f)
			{
				m_counter = m_spawnInterval;
				var roll = GetRandomValue();

				var objectSpawner = m_objectToSpawn.FirstOrDefault(x => x.IsInRange(roll));
				if (objectSpawner == null)
					return;

				var enemy = objectSpawner.SpawnObject();
				var currentPlayerPosition = m_playerTransform.Instance.position;

				StartCoroutine(SpawnCoroutine(enemy));

				return;
			}

			m_counter -= Time.deltaTime;
		}
	}
}