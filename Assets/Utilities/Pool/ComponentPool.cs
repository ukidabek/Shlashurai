using UnityEngine;

namespace Utilities.Pool
{
	public class ComponentPool<T> : Pool<T> where T : Component
	{
		public ComponentPool(T prefab, Transform parent = null, int initialCount = 5) : base(prefab, parent, initialCount)
		{
		}

		public override void Initialize(T prefab, Transform parent = null, int initialCount = 5)
		{
			ValidateIfPoolElementInactive = ValidateIfComponentGameObjectIsInactive;
			CreatePoolElement = CreateInstanceFormPrefab;
			OnPoolElementCreated += DisableGameObject;
			OnPoolElementSelected += ActivateGameObject;
			DisablePoolElement += DisableGameObject;
			base.Initialize(prefab, parent, initialCount);
		}

		private bool ValidateIfComponentGameObjectIsInactive(T arg) => !arg.gameObject.activeSelf;

		private void ActivateGameObject(T component)
		{
			var gameObject = component.gameObject;
			if (gameObject.activeSelf) return;
			gameObject.SetActive(true);
		}

		private void DisableGameObject(T component)
		{
			var gameObject = component.gameObject;
			if (gameObject.activeSelf == false) return;
			gameObject.SetActive(false);
		}
	}
}