using System;
using UnityEngine;

namespace Progress
{
	public class ProgressManager : MonoBehaviour, IProgressManager
	{
		[SerializeField] private ProgressDefinition m_progressDefinition = null;

		[SerializeField] private int m_experience = 0;
		public int Experience => m_experience;

		[SerializeField] private int m_level = 0;
		public int Level => m_level;

		public int NextLevelExperience => m_progressDefinition.GetLevelExperienceAmount(m_level + 1);

		public int CurrentLevelExperience => m_progressDefinition.GetLevelExperienceAmount(m_level);

		public event Action<int> OnLevelChanged = null;
		public event Action<int> OnExperienceAdded = null;

		public void AddExperience(int experience)
		{
			m_experience += experience;
			OnExperienceAdded?.Invoke(experience);

			var level = m_progressDefinition.Evaluate(m_experience, m_level);
			if (m_level != level)
			{
				m_level = level;
				OnLevelChanged?.Invoke(m_level);
			}
		}

		[ContextMenu("Add experience")]
		public void AddExperience() => AddExperience(10);

		[ContextMenu("GoToNextLevel")]
		public void GoToNextLevel()
		{
			var experienceToNextLevel = NextLevelExperience - CurrentLevelExperience;
			AddExperience(experienceToNextLevel);
		}
	}
}
