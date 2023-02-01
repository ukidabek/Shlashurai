using UnityEngine;

namespace Logic.Items
{
    [CreateAssetMenu(fileName = "StackableItem", menuName = "Equipment/Items/StackableItem")]
    public class StackableItem : ItemBase
    {
        [SerializeField] private string _displayName = string.Empty;
        public override string DisplayName => _displayName;
        public override bool IsStackable => true;
    }
}