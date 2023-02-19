using Unity.VisualScripting;
using UnityEngine;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	public class PrefabSpawningSkillEffectPool : Pool<PrefabSpawningSkillEffectTemplate, SkillEfectPrefab>
	{
		private class PrefabSpawningSkillEffectPoolReturner : MonoBehaviour
		{
			public SkillEfectPrefab Prefab { get; set; }
			public PrefabSpawningSkillEffectPool Pool { get; set; }

			private void OnDisable()
			{
				Pool.Return(Prefab);
			}
		}

		public PrefabSpawningSkillEffectPool()
		{
		}

		public override void Initialize(PrefabSpawningSkillEffectTemplate prefab, Transform parent = null, int initialCount = 5)
		{
			ValidateIfPoolElementInactive = ValidateIfPoolElementInactiveLogic;
			CreatePoolElement = CreatePoolElementLogic;
			OnPoolElementCreated = DisablePoolElementLgic;
			DisablePoolElement = DisablePoolElementLgic;

			base.Initialize(prefab, parent, initialCount);
		}

		private void DisablePoolElementLgic(SkillEfectPrefab obj) => obj.gameObject.SetActive(false);

		private bool ValidateIfPoolElementInactiveLogic(SkillEfectPrefab arg) => arg.gameObject.activeSelf == false;

		private SkillEfectPrefab CreatePoolElementLogic(PrefabSpawningSkillEffectTemplate skillEffectTemplate, Transform parent)
		{
			var prefab = skillEffectTemplate.Prefab;
			var instance = GameObject.Instantiate(prefab, parent, false);

			var returner = instance.AddComponent<PrefabSpawningSkillEffectPoolReturner>();
			returner.Pool = this;
			returner.Prefab = instance;

			return instance;
		}
	}
}