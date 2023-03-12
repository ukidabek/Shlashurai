using Shlashurai.Items;
using UnityEngine;

public class ItemPrefabComponent : IItemComponent, IInitializableItemComponent, IDestroyableItemComponent, IManageableItemComponent
{
	public ItemPrefabComponent(ItemBinder prefab)
	{
		Instance = GameObject.Instantiate(prefab);
	}

	public ItemBinder Instance { get; private set; }

	public void Initialize(IItem item) => Instance.Item = item;

	public void SetActive(bool status) => Instance.gameObject.SetActive(status);

	public void Destroy() => GameObject.Destroy(Instance.gameObject);

	public void SetParent(Transform parent, bool wordPositionSays) => Instance.transform.SetParent(parent, wordPositionSays);
}
