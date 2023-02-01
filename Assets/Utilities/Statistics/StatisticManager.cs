using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Logic.Statistics
{
    public class StatisticManager : MonoBehaviour
    {
        public enum GetStatisticMode { All, Any }
        
        [SerializeField] private Statistic[] _statistics = null;

        public T GetStatistic<T>(IEnumerable<StatisticId> id, GetStatisticMode mode = GetStatisticMode.Any) where  T : Statistic
        {
            return mode switch
            {
                GetStatisticMode.All => _statistics.FirstOrDefault(statistic =>
                {
                    var intersection = statistic.ID.Intersect(id);
                    return intersection.Count() == id.Count();
                }) as T,
                GetStatisticMode.Any => _statistics.FirstOrDefault(statistic =>
                {
                    var intersection = statistic.ID.Intersect(id);
                    return intersection.Any();
                }) as T,
                _ => null
            };
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            foreach (var statistic in _statistics) 
                statistic.Tick(deltaTime);
        }

        public void CollectStatistics() => _statistics = GetComponentsInChildren<Statistic>(true);
    }
}