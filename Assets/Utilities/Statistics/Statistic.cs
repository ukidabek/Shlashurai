using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Shlashurai.Statistics
{
	public class Statistic : MonoBehaviour
    {
        [SerializeField] private StatisticId[] _id;
        public IEnumerable<StatisticId> ID => _id;

        [SerializeField] private float _baseValue = 10f;
        public virtual float BaseValue
		{
			get => _baseValue;
			set
			{
				if(_baseValue != value)
                {
                    _baseValue = value;
                    ApplyModifiers();
                }
			}
		}

		[SerializeField] private float _value = 10f;
        public float Value
        {
            get => _value;
            protected set => _value = value;
        }

        public event Action OnStatisticChanged = null;
        
        private readonly List<IStatisticModifier> _modifiers = new List<IStatisticModifier>();
        private readonly List<IUpdatableStatisticModifier> _updatableModifiers = new List<IUpdatableStatisticModifier>();

		protected virtual void Awake() => ApplyModifiers();

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
                Value = statisticModifier.Apply(Value);

            OnStatisticChanged?.Invoke();
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

		public string GetID()
		{
            var stringBuilder = new StringBuilder();
            var lastID = ID.LastOrDefault();
			foreach (var id in ID)
			{
				stringBuilder.Append(id.name);
                if (id == lastID) continue;
				stringBuilder.Append("|");
			}
            return stringBuilder.ToString();
		}
	}
}