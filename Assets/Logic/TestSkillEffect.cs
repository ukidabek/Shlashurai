using Shlashurai.Skill;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Effects/TestSkillEffect", fileName = "TestSkillEffect")]
public class TestSkillEffect : SkillEffect
{
	private IEnumerator Counter()
	{
		var wait = new WaitForSeconds(.25f);
		for (int i = 0; i < 10; i++)
		{
			Debug.Log($"Couting ... {i + 1}");
			yield return wait;
		}
	}
	public override IEnumerator Affect(SkillCastManager skillCastManager, GameObject target) => Counter();
}