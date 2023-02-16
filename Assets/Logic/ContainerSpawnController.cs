using Shlashurai.Items;
using Shlashurai.Spawn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities.Containers;


namespace Shlashurai.Containers
{
	public class ContainerSpawnController : MonoBehaviour, IContainerSpawnController
	{
		[Serializable]
		public class ItemToSpawn
		{
			[SerializeField] private ItemTemplateBase m_item;
			public ItemTemplateBase Item => m_item;

			[SerializeField, Range(0f, 1f)] private float m_Chance = 1f;

			[SerializeField] private int m_amount = 1;
			public int Amount => m_amount;

			public bool CanBeSpawn()
			{
				var roll = UnityEngine.Random.Range(0f, 1f);
				return roll <= m_Chance;
			}
		}

		[SerializeField] private ItemSpawnReferenceHost m_itemSpawnReferenceHost = null;
		[SerializeField] private ItemToSpawn[] m_itemToSpawn = Array.Empty<ItemToSpawn>();
		[SerializeField] private Transform m_spawnPoint = null;
		[SerializeField] private float m_spawnForce = 1000f;
		[SerializeField] private float m_spawnDelay = .25f;

		private IEnumerable<ItemToSpawn> m_itemsToSpawn = null;

		private Queue<IItem> m_itemToSpawnQueue = new Queue<IItem>();

		private Coroutine m_coroutine = null;

		private void Awake() => m_itemsToSpawn = m_itemToSpawn.Where(item => item.CanBeSpawn());

		private void OnEnable() => m_coroutine = StartCoroutine(SpawnCoroutine());

		private void OnDisable() => StopCoroutine(m_coroutine);

		private void OnDestroy() => StopCoroutine(m_coroutine);

		public void Spawn()
		{
			var itemSpawner = m_itemSpawnReferenceHost.Instance;
			foreach (var item in m_itemsToSpawn)
			{
				var length = item.Amount;
				for (int i = 0; i < length; i++)
				{
					var itemInstance = itemSpawner.GetItemInstance(item.Item);
					if (itemInstance == null) continue;

					m_itemToSpawnQueue.Enqueue(itemInstance);
				}
			}
		}

		private IEnumerator SpawnCoroutine()
		{
			while (true)
			{
				while (m_itemToSpawnQueue.Count == 0)
					yield return null;

				var waitForSeconds = new WaitForSeconds(m_spawnDelay);

				while (m_itemToSpawnQueue.Count > 0)
				{
					var itemInstance = m_itemToSpawnQueue.Dequeue();
					var itemPrefab = itemInstance.GetComponet<ItemPrefabComponent>();

					var itemInstanceTransform = itemPrefab.Instance.transform;

					itemInstanceTransform.position = m_spawnPoint.position;
					itemInstanceTransform.rotation = m_spawnPoint.rotation;

					var components = itemInstance.Components;
					foreach (var component in components)
						component.SetActive(true);

					var itemInstanceRigidbody = itemInstanceTransform.GetComponent<Rigidbody>();

					itemInstanceRigidbody.AddForce(itemInstanceTransform.forward * m_spawnForce);

					yield return waitForSeconds;
				}
			}
		}
	}
}