using UnityEngine;

namespace Skills
{
	public abstract class SkillPostProcessor : MonoBehaviour
	{
		[SerializeField] private SkillCastManager m_skillCastManager = null;

		private void Awake()
		{
			m_skillCastManager.OnSkillCastBegin += SkillCastBegin;
			m_skillCastManager.OnSkillCastEnd += SkillCastEnd;
		}

		private void OnDestroy()
		{
			m_skillCastManager.OnSkillCastBegin -= SkillCastBegin;
			m_skillCastManager.OnSkillCastEnd -= SkillCastEnd;
		}

		protected virtual void SkillCastBegin(ISkill skill) { }
		protected virtual void SkillCastEnd(ISkill skill) { }

		private void Reset()
		{
			m_skillCastManager = GetComponent<SkillCastManager>();
		}
	}
}