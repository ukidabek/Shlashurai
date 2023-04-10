using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shlashurai.Statistics
{
	public abstract class StatisticApplyLogic : MonoBehaviour
	{
		protected abstract Statistic[] Statistics { get; }
		protected IEnumerable<Statistic> ValidStatistics = null;

		public abstract void Apply();

		protected virtual void Awake() => ValidStatistics = Statistics.Where(statistic => statistic != null);

		protected virtual void OnEnable()
		{
			foreach (var statistic in ValidStatistics)
				statistic.OnStatisticChanged += Apply;
		}

		protected virtual void OnDisable()
		{
			foreach (var statistic in ValidStatistics)
				statistic.OnStatisticChanged -= Apply;
		}

		protected virtual void OnDestroy()
		{
			foreach (var statistic in ValidStatistics)
				statistic.OnStatisticChanged -= Apply;
		}
	}
}