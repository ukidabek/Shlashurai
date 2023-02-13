using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Utilities.ReferenceHost;
using Utilities.Pool;
using System.Collections;
using UnityEditor.Search;
using System.Collections.Generic;

namespace Shlashurai.Logic
{
	public class Spawn : MonoBehaviour
    {
        [Serializable]
        public class ObjectToSpawn
        {
            [SerializeField] private GameObject m_gameObjectToSpan = null;
            [SerializeField] private float m_chance = 1.0f;
			public float Chance => m_chance;

            private GameObjectPool m_gameObjectPool = null;

            private Vector2 m_range = Vector2.zero;

            public void Initialize(Spawn spawn, float previousChande)
            {
                m_gameObjectPool = new GameObjectPool(m_gameObjectToSpan, spawn.transform);
                m_gameObjectPool.OnPoolElementSelected = null;
                m_range.Set(previousChande, previousChande + m_chance);
			}

            public bool IsInRange(float roll) => m_range.x <= roll && m_range.y >= roll;

			public GameObject SpawnEnemy() => m_gameObjectPool.Get();
		}

        [SerializeField] private ObjectToSpawn[] m_objectToSpawn = Array.Empty<ObjectToSpawn>();
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
                item.Initialize(this, previousChande);
                previousChande = item.Chance;
            }
        }

		private float GetRandomValue() => UnityEngine.Random.Range(0f, m_totalChande);

        private IEnumerator SpawnCoroutine(GameObject enemy)
        {
            Vector3 currentPlayerPosition = Vector3.zero;
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

                var enemy = objectSpawner.SpawnEnemy();
                var currentPlayerPosition = m_playerTransform.Instance.position;

                StartCoroutine(SpawnCoroutine(enemy));

                return;
            }

            m_counter -= Time.deltaTime;
        }
    }
}