using UnityEngine;

namespace Shlashurai.Spawn
{
	[CreateAssetMenu(menuName = "Spawn/Spawn/SpellEffectSpawn", fileName = "SpellEffectSpawn")]
	public class SpellEffectSpawn : SpawnBase<PrefabSpawningSkillEffectPool, PrefabSpawningSkillEffect, SkillEfectPrefab, SkillEfectPoolHandelr>
	{
	}
}