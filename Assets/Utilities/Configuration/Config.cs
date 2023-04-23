using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Configuration
{
	public abstract class Config : ScriptableObject
	{
		public abstract IEnumerable<ISetting> Settings { get; }
	}
}