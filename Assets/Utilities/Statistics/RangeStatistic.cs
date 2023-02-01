using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Logic.Statistics
{
    public class RangeStatistic : Statistic
    {
        [SerializeField] private float _minValue = 0f;
        public float MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        [SerializeField] private float _currentValue = 0;
        public float CurrentValue
        {
            get => _currentValue;
            set
            {
                var newValue = Mathf.Clamp(value, MinValue, Value);
                if (_currentValue == newValue) return;
                _currentValue = newValue;
                OnCurrentValueChanged.Invoke(_currentValue);
            }
        }

        [SerializeField] private List<RangeStatisticLogic> _rangeStatisticLogic = new List<RangeStatisticLogic>();

        public UnityEvent<float> OnCurrentValueChanged = new UnityEvent<float>();
        
        protected override void Awake()
        {
            base.Awake();
            foreach (var rangeStatisticLogic in _rangeStatisticLogic) 
                rangeStatisticLogic.Initialize(this);

            CurrentValue = Value;
        }

        public override void Tick(float deltaTime)
        {
            base.Tick(deltaTime);
            foreach (var rangeStatisticLogic in _rangeStatisticLogic) 
                rangeStatisticLogic.Tick(deltaTime);
        }
    }
}