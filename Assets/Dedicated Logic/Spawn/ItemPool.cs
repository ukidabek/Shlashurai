using Utilities.Pool;
using Shlashurai.Items;
using UnityEngine;
using Unity.VisualScripting;

namespace Shlashurai.Spawn
{
	public class ItemPool : Pool<ItemTemplateBase, IItem> 
	{
		public class ItemPoolReturner : MonoBehaviour
		{
			private ItemBinder itemBinder = null;
			public ItemPool Pool { get; set; }

			protected void OnDisable()
			{
				var cpomponents = itemBinder.Item.Components;
				foreach (var component in cpomponents)
					component.SetActive(false);
				Pool.Return(itemBinder.Item);
			}

			private void Awake()
			{
				itemBinder = GetComponent<ItemBinder>();
			}
		}
		public override void Initialize(ItemTemplateBase prefab, Transform parent = null, int initialCount = 5)
		{
			CreatePoolElement = OnCreatePoolElement;
			ValidateIfPoolElementInactive = ValidateIfPoolElementIsInactive;
			DisablePoolElement = PoolElementDisableLogic;
			OnPoolElementSelected = PoolElementSelected;

			base.Initialize(prefab, parent, initialCount);
		}

		private void PoolElementSelected(IItem item) => item.IsActive = true;

		private void PoolElementDisableLogic(IItem item) => item.IsActive = false;

		private bool ValidateIfPoolElementIsInactive(IItem item) => !item.IsActive;

		private IItem OnCreatePoolElement(ItemTemplateBase itemTemplate, Transform parent)
		{
			var itemInstance = itemTemplate.Create();
			itemInstance.IsActive = false;

			var components = itemInstance.Components;
			foreach (var component in components)
				component.SetActive(false);

			var ItemPrefabComponent = itemInstance.GetComponet<ItemPrefabComponent>();
			if (ItemPrefabComponent != null)
			{
				ItemPrefabComponent.SetParent(parent, false);
				var returner = ItemPrefabComponent.Instance.AddComponent<ItemPoolReturner>();
				returner.Pool = this;
			}

			return itemInstance;
		}
	}
}