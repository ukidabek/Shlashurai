using Shlashurai.Skill;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Effects/PrefabSpawningSkillEffect", fileName = "PrefabSpawningSkillEffect")]
public class PrefabSpawningSkillEffect : SkillEffect
{
	[SerializeField] private GameObject m_prefab = null;
	public override IEnumerator Affect(SkillCastManager skillCastManager, GameObject target)
	{
		var spawnPoint = skillCastManager.SkillSpawnPoint;
		var instance = GameObject.Instantiate(m_prefab, spawnPoint.position, spawnPoint.rotation);

		instance.SetActive(true);

		return null;
	}
}