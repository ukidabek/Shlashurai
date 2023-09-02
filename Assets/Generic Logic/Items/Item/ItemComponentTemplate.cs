using UnityEngine;

namespace Items
{
	public abstract class ItemComponentTemplate : ScriptableObject
	{
		public abstract IItemComponent Create();
	}
}