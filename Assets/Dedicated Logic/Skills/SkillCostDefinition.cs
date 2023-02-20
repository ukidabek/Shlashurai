using Shlashurai.Characters;
using System;
using UnityEngine;

[Serializable]
public class SkillCostDefinition
{
	[SerializeField] private ResourceID m_id = null;
	public ResourceID Id => m_id;

	[SerializeField] private float m_cost;
	public float Cost => m_cost;
}
