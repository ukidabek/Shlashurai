using UnityEngine;

namespace Utilities.Configuration
{
	public abstract class SettingHandler : MonoBehaviour, ISettingHandler
	{
		public abstract bool CanHandle(ISetting obj);

		public abstract void Handle(ISetting obj);
	}
}
