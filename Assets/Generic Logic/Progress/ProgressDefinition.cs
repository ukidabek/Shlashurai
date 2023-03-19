using UnityEngine;

namespace Progress
{
	public abstract class ProgressDefinition : ScriptableObject
	{
		public abstract int Evaluate(float experience, int currentLevel);
	}
}
