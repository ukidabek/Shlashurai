using UnityEngine;

namespace Logic.Items
{
    public abstract  class ItemBase : ScriptableObject, IItem
    {
        public string Name => name;
        public abstract string DisplayName { get; }
        public abstract bool IsStackable { get; }
    }
}