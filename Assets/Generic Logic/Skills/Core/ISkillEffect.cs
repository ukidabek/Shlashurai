using System.Collections;
using UnityEngine;

namespace Skills
{
	public interface ISkillEffect
	{
		void Affect(SkillCastManager skillCastManager, GameObject target);
	}
}