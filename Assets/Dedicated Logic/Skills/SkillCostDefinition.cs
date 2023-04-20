using Shlashurai.Characters;
using System;
using UnityEngine;

namespace Shlashurai.Skills
{
	[Serializable]
	public class SkillCostDefinition
	{
		[SerializeField] private ResourceID m_id = null;
		public ResourceID Id => m_id;

		[SerializeField] private float m_cost;
		public float Cost => m_cost;
	}
}