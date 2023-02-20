using Shlashurai.Characters;
using Shlashurai.Skill;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Templates/Effects/HealSkillEffectTemplate", fileName = "HealSkillEffectTemplate")]
public class HealSkillEffectTemplate : SkillEffectTemplateBase
{
	[SerializeField] private ResourceID m_id = null;
	[SerializeField] private float m_amount = 10f;

	public class HealSkillEffect : ISkillEffect
	{
		private float m_amount = 10f;

		private ResourceHandler m_resourceHandler = null;

		public HealSkillEffect(ResourceID id, float amount)
		{
			m_amount = amount;
			m_resourceHandler = new ResourceHandler()
			{
				ResourceID = id,
			};
		}

		public void Affect(SkillCastManager skillCastManager, GameObject target)
		{
			m_resourceHandler.ResourceManager = target.GetComponent<ResourceManager>();
			m_resourceHandler.Value += m_amount;
		}
	}

	public override ISkillEffect Create() => new HealSkillEffect(m_id, m_amount);
}
