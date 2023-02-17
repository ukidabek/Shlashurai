using Shlashurai.Characters;
using Shlashurai.Skill;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Effects/HealSkillEffect", fileName = "HealSkillEffect")]
public class HealSkillEffect : SkillEffect
{
	[SerializeField] private ResourceID m_id = null;
	[SerializeField] private float m_amount = 10f;

	public override IEnumerator Affect(SkillCastManager skillCastManager, GameObject target)
	{
		var resourceManager = target.GetComponent<ResourceManager>();
		if (resourceManager == null) return null;

		var resource = resourceManager.GetResource(m_id);

		if (resource == null) return null;

		resource.Value += m_amount;

		return null;
	}
}