using UnityEngine;

namespace Logic.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Equipment/Items/Item")]
    public class ItemWitchPrefab : ItemBase
    {
        public override string DisplayName => _itemPrefab.DisplayName;

        [SerializeField] private bool _isStackable = false;
        public override bool IsStackable => _isStackable;

        [SerializeField] private ItemData _itemPrefab = null;
        public ItemData ItemPrefab => _itemPrefab;

        protected virtual void OnEnable() {}
    }
}