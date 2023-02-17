using Shlashurai.Skill;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Skill/Skill", fileName = "Skill")]
public class Skill : ScriptableObject, ISkill
{
	[SerializeField] private SkillEffect[] m_skilEffects = null;
	public IEnumerable<ISkillEffect> Effects => m_skilEffects;

	[SerializeField] private SkillCost m_skillCost = null;
	public ISkillCost Cost => m_skillCost;
}