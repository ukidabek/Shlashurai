using Shlashurai.Skill;
using Shlashurai.Spawn;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Effects/PrefabSpawningSkillEffect", fileName = "PrefabSpawningSkillEffect")]
public class PrefabSpawningSkillEffect : SkillEffect
{
	[SerializeField] private bool m_spawnOnSelf = false;
	[SerializeField] private SpellEffectSpawn m_skillEffectSpawn = null;

	public override IEnumerator Affect(SkillCastManager skillCastManager, GameObject target)
	{
		var effect = m_skillEffectSpawn.GetItemInstance(this);
		var effectTransform = effect.transform;
		var skillSpawnTransform = m_spawnOnSelf ? skillCastManager.transform : skillCastManager.SkillSpawnPoint;
		effectTransform.position = skillSpawnTransform.position;
		effectTransform.rotation = skillSpawnTransform.rotation;

		effect.gameObject.SetActive(true);

		return null;
	}
}