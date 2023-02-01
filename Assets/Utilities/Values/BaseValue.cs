using System;
using UnityEngine;

namespace Utilities.Values
{
    public abstract class BaseValue : ScriptableObject
    {
        public abstract Type ValueType { get; }
        public abstract object Value { get; set; }
    }

    public class BaseValue<T> : BaseValue
    {
        public event Action<T> OnValueChange = null;

        [SerializeField] private T m_value;

        public override Type ValueType => typeof(T);

        public override object Value
        {
            get => m_value;
            set
            {
                if (value != null && value is not T) return;
                var _value = (T) value;
                
                if (m_value == null || !m_value.Equals(_value))
                    OnValueChange?.Invoke(_value);
                m_value = _value;
            }
        }

        public void SetValue(T value) => Value = value;

        public static implicit operator T(BaseValue<T> value) => value.m_value;
    }
}