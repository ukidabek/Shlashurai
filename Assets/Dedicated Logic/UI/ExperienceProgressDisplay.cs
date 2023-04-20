using Progress;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities.ReferenceHost;

namespace Shlashurai.UI
{
	public class ExperienceProgressDisplay : MonoBehaviour
	{
		[Inject] private IProgressManager m_progressManager = null;
		[SerializeField] private Slider m_experienceProgress = null;

		public void Initialize()
		{
			if (m_progressManager == null) return;
			m_progressManager.OnExperienceAdded += OnExperienceAdded;
			m_progressManager.OnLevelChanged += OnExperienceAdded;
			OnExperienceAdded();
		}

		private void OnDestroy()
		{
			if (m_progressManager == null) return;
			m_progressManager.OnExperienceAdded -= OnExperienceAdded;
			m_progressManager.OnLevelChanged -= OnExperienceAdded;
		}

		private void OnExperienceAdded(int obj = 0)
		{
			var currentLevelExperience = m_progressManager.CurrentLevelExperience;
			var nextLevelExperience = m_progressManager.NextLevelExperience;

			var experienceDoGet = nextLevelExperience - currentLevelExperience;
			var experienceDelta = Math.Abs(currentLevelExperience - m_progressManager.Experience);
			var experienceCollectingProgress = experienceDelta / (float)experienceDoGet;

			m_experienceProgress.value = experienceCollectingProgress;
		}
	}
}