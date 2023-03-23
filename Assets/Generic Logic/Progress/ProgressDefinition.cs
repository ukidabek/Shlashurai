using UnityEngine;

namespace Progress
{
	public abstract class ProgressDefinition : ScriptableObject
	{
		public abstract int GetLevelExperienceAmount(int currentLevel);
		public abstract int Evaluate(int experience, int currentLevel);
	}
}
