using UnityEngine;

namespace Progress
{
	[CreateAssetMenu(fileName = "DefaultProgressDefinition", menuName = "Progress/DefaultProgressDefinition")]
	public class DefaultProgressDefinition : ProgressDefinition
	{
		[SerializeField] private int m_experiencePerLevel = 100;
		[SerializeField, Range(0f, 2f)] private float m_experienceMultiplayer = 1.2f;

		public override int Evaluate(int experience, int currentLevel)
		{
			var nextLevelExperienceAmount = GetLevelExperienceAmount(currentLevel + 1);
			return GetLevel(experience, nextLevelExperienceAmount, currentLevel);
		}

		public override int GetLevelExperienceAmount(int currentLevel)
			=> Mathf.FloorToInt((m_experiencePerLevel * currentLevel) * m_experienceMultiplayer);

		private int GetLevel(int experience, float targetExperience, int currentLevel)
			=> experience >= targetExperience ? currentLevel + 1 : currentLevel;
	}
}
