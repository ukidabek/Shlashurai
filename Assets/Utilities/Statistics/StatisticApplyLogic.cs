using UnityEngine;

namespace Shlashurai.Statistics
{
	public abstract class StatisticApplyLogic : MonoBehaviour
	{
		[SerializeField] protected Statistic m_statisticToApply = null;
		public abstract void Apply();

		private void OnEnable()
		{
			if (m_statisticToApply == null) return;
			m_statisticToApply.OnStatisticChanged += Apply;
		}

		private void OnDisable()
		{
			if (m_statisticToApply == null) return;
			m_statisticToApply.OnStatisticChanged -= Apply;
		}

		private void OnDestroy()
		{
			if (m_statisticToApply == null) return;
			m_statisticToApply.OnStatisticChanged -= Apply;
		}
	}
}