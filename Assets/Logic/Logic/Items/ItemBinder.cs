using UnityEngine;

namespace Shlashurai.Items
{
	public abstract class ItemBinder : MonoBehaviour
    {
		 public IItem Item { get; internal set; }

		[ContextMenu("Show item status")]
		private void ShowItemStatus()
		{
			Debug.Log($"Status for item: {Item} is {Item.IsActive}");
		}
	}
}