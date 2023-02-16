using UnityEngine;

namespace Shlashurai.Items
{
	public abstract class ItemComponentTemplate : ScriptableObject
	{
		public abstract IItemComponent Create();
	}
}