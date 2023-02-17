using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Skil
{
    public interface ISkillEffect
    {
		IEnumerator Affect(SkillCastManager skillCastManager, GameObject target);
	}

    public interface ISkillCost { }

	public interface ISkill
    {
        IEnumerable<ISkillEffect> Effects { get; }
		ISkillCost Cost { get; }
    }
}