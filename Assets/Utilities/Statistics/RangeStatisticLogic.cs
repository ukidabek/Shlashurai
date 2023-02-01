using UnityEngine;

namespace Logic.Statistics
{
    public abstract class RangeStatisticLogic : MonoBehaviour
    {
        protected RangeStatistic _rangeStatistic;

        public virtual void Initialize(RangeStatistic rangeStatistic)
        {
            _rangeStatistic = rangeStatistic;
        }
        
        public abstract void Tick(float deltaTime);
    }
}