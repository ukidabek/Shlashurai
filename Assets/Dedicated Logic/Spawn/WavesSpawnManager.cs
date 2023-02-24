using System.Linq;
using UnityEngine;
using System;
using System.Collections.Generic;
using Utilities.General;
using System.Collections;

namespace Shlashurai.Spawn
{
	public class WavesSpawnManager : MonoBehaviour
	{
		[Serializable]
		public class Wave
		{
			[SerializeField] private Spawn[] m_enemyToSpawn = null;
			[SerializeField] private float m_delay = 0f;
			public float Delay { get => m_delay; }

			public void Initialize()
			{
				Spawn.Initialize(m_enemyToSpawn);
				WaveEnemy = m_enemyToSpawn
					.Where(x => x.Roll())
					.Select(x => x.ObjectToSpawn);
			}

			public IEnumerable<GameObject> WaveEnemy { get; private set; }
		}

		[SerializeField] private Wave[] waves = null;
		[SerializeField] private GameObjectSpawn m_spawn = null;
		[SerializeField] private Transform[] m_spawnPoints = null;

		private CoroutineManager m_coroutineManager = null;

		private IEnumerable<Transform> m_randomTransform = null;

		private void Awake()
		{
			m_coroutineManager = new CoroutineManager(this, SpawnCoroutine());
			m_randomTransform = m_spawnPoints.OrderBy(spawn => UnityEngine.Random.Range(0f, 1f));
			foreach (var item in waves)
				item.Initialize();

		}

		private void OnTriggerEnter(Collider other)
		{
			m_coroutineManager.Run();
		}

		private IEnumerator SpawnCoroutine()
		{
			foreach (var w in waves)
			{
				yield return new WaitForSeconds(w.Delay);

				foreach (var item in w.WaveEnemy)
				{
					var instance = m_spawn.GetInstance(item);
					var spawnPoint = m_randomTransform.FirstOrDefault();

					instance.transform.position = spawnPoint.position;
					instance.SetActive(true);
				}
			}
			yield return null;

			gameObject.SetActive(false);
		}
	}
}