using System;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
	public interface ISkill
	{
		Sprite Image { get; }
		IEnumerable<ISkillEffect> Effects { get; }
		ISkillCost Cost { get; }
		IEnumerable<ISkillStatus> Status { get; }

		event Action<ISkillStatus> SkillStatusAdded;
		event Action<ISkillStatus> SkillStatusRemoved;

		void AddStatus(ISkillStatus status);
		void RemoveStatus(ISkillStatus status);
	}
}