using UnityEngine;

namespace Shlashurai.Skill
{
	public abstract class Template<T> : ScriptableObject 
    {
		public abstract T Create();
	}
}