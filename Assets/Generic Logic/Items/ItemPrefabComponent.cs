using UnityEngine;

namespace Shlashurai.Items
{
	public class ItemPrefabComponent : IItemComponent
	{
		public ItemPrefabComponent(ItemBinder prefab)
		{
			Instance = GameObject.Instantiate(prefab);
		}

		public ItemBinder Instance { get; private set; }

		public void Initialize(IItem item) => Instance.Item = item;

		public void SetActive(bool status) => Instance.gameObject.SetActive(status);

		public void Destory() => GameObject.Destroy(Instance.gameObject);

		public void SetParent(Transform parent, bool worlPositionSays) => Instance.transform.SetParent(parent, worlPositionSays);
	}
}