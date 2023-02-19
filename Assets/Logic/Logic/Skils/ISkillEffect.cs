using System.Collections;
using UnityEngine;

namespace Shlashurai.Skill
{
	public interface ISkillEffect
    {
		void Affect(SkillCastManager skillCastManager, GameObject target);
	}
}