using Shlashurai.Skil;
using System.Collections;
using UnityEngine;

public abstract class SkillEffect : ScriptableObject, ISkillEffect
{
	public abstract IEnumerator Affect(SkillCastManager skillCastManager, GameObject target);
}
