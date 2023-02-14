using System;
using UnityEngine;

namespace Utilities.Pool
{
	public class GameObjectPool : Pool<GameObject>
	{
		public class GameObjectPoolReturner : PoolReturnerBase<GameObject, GameObjectPool> { }

		public GameObjectPool() : base() { }
		
		public GameObjectPool(GameObject prefab, Transform parent = null, int initialCount = 5) : base(prefab, parent, initialCount) { }

		private bool ValidateIfGameObjectIsActive(GameObject gameObject) => !gameObject.activeSelf;

		private void ActivateGameObject(GameObject gameObject)
		{
			if (gameObject.activeSelf) return;
			gameObject.SetActive(true);
		}

		private void DisableGameObject(GameObject gameObject)
		{
			if (gameObject.activeSelf == false) return;
			gameObject.SetActive(false);
		}

		public override void Initialize(GameObject prefab, Transform parent = null, int initialCount = 5)
		{
			ValidateIfPoolElementInactive = ValidateIfGameObjectIsActive;
			CreatePoolElement = CreateGameObjectInstanceFormPrefab;
			OnPoolElementCreated = AddPoolReturtner;
			OnPoolElementSelected = ActivateGameObject;
			DisablePoolElement = DisableGameObject;
			base.Initialize(prefab, parent, initialCount);
		}

		private void AddPoolReturtner(GameObject obj)
		{
			var gameObjectPool = obj.AddComponent<GameObjectPoolReturner>();
			gameObjectPool.Pool = this;
		}
	}
}