using Shlashurai.Characters;
using Shlashurai.Skil;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Skils/Effects/SkillHealEffect", fileName = "SkillHealEffect")]
public class SkillHealEffect : SkillEffect
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