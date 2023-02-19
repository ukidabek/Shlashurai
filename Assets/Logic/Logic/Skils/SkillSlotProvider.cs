using System.Linq;
using UnityEngine;

namespace Shlashurai.Skill
{
	public class SkillSlotProvider : MonoBehaviour
	{
		[SerializeField] private SkillTemplate [] m_skillTemplate = null;
		[SerializeField] private SkillHolder m_skillHolder = null;

		private void Awake()
		{
			var skills = m_skillTemplate.Select(template => template.Create()).ToArray();

			var length = skills.Length;
			for (int i = 0; i < length; i++)
				m_skillHolder.SetSkillToSlot(i, skills[i]);
		}

		private void Reset()
		{
			m_skillHolder = GetComponent<SkillHolder>();
		}
	}
}