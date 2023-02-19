using UnityEngine;

namespace Shlashurai.Items
{
	public abstract class TemplateBase<T> : ScriptableObject
	{
		public abstract T Create();
	}
}