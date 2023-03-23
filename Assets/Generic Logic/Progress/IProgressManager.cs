using System;

namespace Progress
{
	public interface IProgressManager
	{
		int Experience { get; }
		int NextLevelExperience { get; }
		int CurrentLevelExperience { get; }
		int Level { get; }
		void AddExperience(int experience);
		event Action<int> OnLevelChanged;
		event Action<int> OnExperienceAdded;
	}
}