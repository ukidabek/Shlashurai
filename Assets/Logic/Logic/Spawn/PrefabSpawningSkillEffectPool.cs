using Unity.VisualScripting;
using UnityEngine;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	public class PrefabSpawningSkillEffectPool : Pool<PrefabSpawningSkillEffect, SkillEfectPrefab>
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

		private readonly SkillEfectPrefab m_skillEfectPrefab;

		public PrefabSpawningSkillEffectPool()
		{
		}

		public PrefabSpawningSkillEffectPool(SkillEfectPrefab skillEfectPrefab)
		{
			m_skillEfectPrefab = skillEfectPrefab;
		}

		public override void Initialize(PrefabSpawningSkillEffect prefab, Transform parent = null, int initialCount = 5)
		{
			ValidateIfPoolElementInactive = ValidateIfPoolElementInactiveLogic;
			CreatePoolElement = CreatePoolElementLogic;
			OnPoolElementCreated = DisablePoolElementLgic;
			DisablePoolElement = DisablePoolElementLgic;

			base.Initialize(prefab, parent, initialCount);
		}

		private void DisablePoolElementLgic(SkillEfectPrefab obj) => obj.gameObject.SetActive(false);

		private bool ValidateIfPoolElementInactiveLogic(SkillEfectPrefab arg) => arg.gameObject.activeSelf == false;

		private SkillEfectPrefab CreatePoolElementLogic(PrefabSpawningSkillEffect arg1, Transform arg2)
		{
			var instance = GameObject.Instantiate(m_skillEfectPrefab, arg2, false);
			var returner = instance.AddComponent<PrefabSpawningSkillEffectPoolReturner>();
			returner.Pool = this;
			returner.Prefab = instance;

			return instance;
		}
	}
}