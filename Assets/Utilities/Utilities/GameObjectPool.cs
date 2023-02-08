using UnityEngine;

namespace Utilities.General
{
	public class GameObjectPool : Pool<GameObject>
	{
		private class GameObjectPoolReturner : MonoBehaviour
		{
			public GameObjectPool Pool { get; set; }

			private void OnDisable() => Pool.Return(this.gameObject);
		}

		public GameObjectPool(GameObject prefab, Transform parent = null, int initialCount = 5) : base(prefab, parent, initialCount)
		{
		}

		private GameObject CreateGameObjectInstanceFormPrefab(GameObject prefab, Transform parent)
			=> GameObject.Instantiate(prefab, parent, false);

		private void AddPoolReturner(GameObject obj)
		{
			var poolReturner = obj.AddComponent<GameObjectPoolReturner>();
			poolReturner.Pool = this;
		}

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

		protected override void Initialize()
		{
			base.Initialize();
			ValidateIfPoolElementInactive = ValidateIfGameObjectIsActive;
			CreatePoolElement = CreateGameObjectInstanceFormPrefab;
			OnPoolElementCreated = AddPoolReturner;
			OnPoolElementSelected = ActivateGameObject;
			DisablePoolElement = DisableGameObject;
		}
	}
}