using UnityEngine;

namespace Utilities.Pool
{
	public class ComponentPool<T> : Pool<T> where T : Component
	{
		public override void Initialize(T prefab, Transform parent = null, int initialCount = 5)
		{
			ValidateIfPoolElementInactive = ValidateIfComponentGameObjectIsActive;
			CreatePoolElement = CreateInstanceFormPrefab;
			OnPoolElementCreated += DisableGameObject;
			OnPoolElementSelected += ActivateGameObject;
			DisablePoolElement += DisableGameObject;
			base.Initialize(prefab, parent, initialCount);
		}

		private bool ValidateIfComponentGameObjectIsActive(T arg) => arg.gameObject.activeSelf;

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