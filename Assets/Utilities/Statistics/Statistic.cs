using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Logic.Statistics
{
    public class Statistic : MonoBehaviour
    {
        [SerializeField] private StatisticId[] _id;
        public StatisticId[] ID => _id;

        [SerializeField] private float _baseValue = 10f;
        public virtual float BaseValue
        {
            get => _baseValue;
            set => _baseValue = value;
        }

        [SerializeField] private float _value = 10f;
        public float Value
        {
            get => _value;
            protected set => _value = value;
        }

        public UnityEvent<float> OnBaseValueChanged = new UnityEvent<float>();
        public UnityEvent<float> OnValueChanged = new UnityEvent<float>();
        
        private readonly List<IStatisticModifier> _modifiers = new List<IStatisticModifier>();
        private readonly List<IUpdatableStatisticModifier> _updatableModifiers = new List<IUpdatableStatisticModifier>();

        protected virtual void Awake()
        {
            OnBaseValueChanged.Invoke(BaseValue);
            ApplyModifiers();
            OnValueChanged.Invoke(Value);
        }

        public void AddModifier(IStatisticModifier modifier)
        {
            _modifiers.Add(modifier);
            
            if (_modifiers is IUpdatableStatisticModifier updatableModifier)
                _updatableModifiers.Add(updatableModifier);
            
            ApplyModifiers();
        }

        public void RemoveModifier(IStatisticModifier modifier)
        {
            _modifiers.Remove(modifier);

            if (_modifiers is IUpdatableStatisticModifier updatableModifier)
                _updatableModifiers.Remove(updatableModifier);
            
            ApplyModifiers();
        }

        protected void ApplyModifiers()
        {
            _modifiers.Sort(CompareModifierOrder);
            Value = BaseValue;
            foreach (var statisticModifier in _modifiers)
            {
                Value = statisticModifier.Apply(Value);
            }
        }

        private int CompareModifierOrder(IStatisticModifier x, IStatisticModifier y)
        {
            if (x.Order < x.Order) return -1;
            if (x.Order > x.Order) return 1;
            return 0;
        }

        public virtual void Tick(float deltaTime)
        {
            foreach (var updatableStatisticModifier in _updatableModifiers)
                updatableStatisticModifier.Tick(deltaTime);
        }
    }
}