using UnityEngine;

namespace Shlashurai.Spawn
{
	[CreateAssetMenu(menuName = "Spawn/Handler/SkillEfectPoolHandelr", fileName = "SkillEfectPoolHandelr")]
	public class SkillEfectPoolHandelr : PoolHandler<PrefabSpawningSkillEffectPool, PrefabSpawningSkillEffect, SkillEfectPrefab>
	{
		[SerializeField] private SkillEfectPrefab m_skillEfectPrefab;
		public override void Initialize(Transform parent)
		{
			base.Initialize(parent);
			m_pool = new PrefabSpawningSkillEffectPool(m_skillEfectPrefab);
			m_pool.Initialize(m_objectToSpan, m_poolTransform);
		}
	}
}