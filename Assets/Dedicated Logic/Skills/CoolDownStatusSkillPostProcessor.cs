using Shlashurai.Skill;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownStatusSkillPostProcessor : SkillPostProcessor
{
	private List<KeyValuePair<ISkill, CoolDownSkillStatus>> m_coolDownStatusesList = new List<KeyValuePair<ISkill, CoolDownSkillStatus>>();

	protected override void SkillCastEnd(ISkill skill)
	{
		var coolDownTime = skill.Cost.CoolDownTime;
		if (coolDownTime == 0) return;

		var coolDownStatus = new CoolDownSkillStatus(coolDownTime);
		skill.AddStatus(coolDownStatus);
		m_coolDownStatusesList.Add(new KeyValuePair<ISkill, CoolDownSkillStatus>(skill, coolDownStatus));
	}

	private void Update()
	{
		var deltaTime = Time.deltaTime * Time.timeScale;

		var count = m_coolDownStatusesList.Count;
		for (int i = 0; i < count; i++)
		{
			if (m_coolDownStatusesList[i].Value.Tick(deltaTime))
			{
				var skill = m_coolDownStatusesList[i].Key;
				var status = m_coolDownStatusesList[i].Value;
				skill.RemoveStatus(status);
				m_coolDownStatusesList.RemoveAt(i);
				--count;
			}
		}
	}
}