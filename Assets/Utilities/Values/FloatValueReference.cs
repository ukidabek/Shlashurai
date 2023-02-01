using System;

namespace Utilities.Values
{
    [Serializable]
    public class FloatValueReference : BaseValueReference<FloatValue, float>
    {
        public FloatValueReference(float defaultValue) : base(defaultValue)
        {
        }
    }
}