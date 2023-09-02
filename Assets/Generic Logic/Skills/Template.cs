using UnityEngine;

namespace Skills
{
	public abstract class Template<T> : ScriptableObject
	{
		public abstract T Create();
	}
}