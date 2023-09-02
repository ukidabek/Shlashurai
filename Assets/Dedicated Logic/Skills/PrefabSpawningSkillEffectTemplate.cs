using Shlashurai.Skills.Utilities;
using Shlashurai.Spawn;
using Skills;
using UnityEngine;

namespace Shlashurai.Skills
{
	[CreateAssetMenu(menuName = "Skills/Templates/Effects/PrefabSpawningSkillEffectTemplate", fileName = "PrefabSpawningSkillEffectTemplate")]
	public class PrefabSpawningSkillEffectTemplate : SkillEffectTemplateBase
	{
		private class PrefabSpawningSkillEffect : ISkillEffect
		{
			private bool m_spawnOnSelf = false;
			private EffectSpawnHandler m_effectSpawnChandler = null;

			public PrefabSpawningSkillEffect(bool spawnOnSelf, EffectSpawnHandler effectSpawnChandler)
			{
				m_spawnOnSelf = spawnOnSelf;
				m_effectSpawnChandler = effectSpawnChandler;
			}

			public void Affect(SkillCastManager skillCastManager, GameObject target)
			{
				var skillManagerGameObject = skillCastManager.gameObject;

				var effect = m_effectSpawnChandler.GetItemInstance();
				effect.gameObject.layer = skillManagerGameObject.layer;

				var effectTransform = effect.transform;
				var skillSpawnTransform = GetTransform(skillCastManager);
				effectTransform.position = skillSpawnTransform.position;
				effectTransform.rotation = skillSpawnTransform.rotation;

				var damageDealer = effect.GetComponent<DamageDealer>();
				damageDealer?.SetDamagingObject(skillManagerGameObject);

				effect.gameObject.SetActive(true);
			}

			private Transform GetTransform(SkillCastManager skillCastManager)
				=> m_spawnOnSelf ? skillCastManager.transform : skillCastManager.SkillSpawnPoint;
		}

		private class EffectSpawnHandler
		{
			private PrefabSpawningSkillEffectTemplate Template { get; }
			private SpellEffectSpawn Spawn { get; }

			public EffectSpawnHandler(PrefabSpawningSkillEffectTemplate template, SpellEffectSpawn spawn)
			{
				Template = template;
				Spawn = spawn;
			}

			public SkillEfectPrefab GetItemInstance() => Spawn.GetInstance(Template);
		}

		[SerializeField] private bool m_spawnOnSelf = false;
		[SerializeField] private SpellEffectSpawn m_skillEffectSpawn = null;
		[SerializeField] private SkillEfectPrefab m_prefab = null;
		public SkillEfectPrefab Prefab => m_prefab;

		public override ISkillEffect Create()
		{
			var handler = new EffectSpawnHandler(this, m_skillEffectSpawn);
			return new PrefabSpawningSkillEffect(m_spawnOnSelf, handler);
		}
	}
}