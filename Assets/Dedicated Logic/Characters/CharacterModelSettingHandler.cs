using UnityEngine;
using Utilities.Configuration;

namespace Shlashurai.Character
{
	public class CharacterModelSettingHandler : MonoBehaviour, ISettingHandler
	{
		public bool CanHandle(ISetting obj) => obj is CharacterModelSetting;

		public void Handle(ISetting obj)
		{
			var model = obj as CharacterModelSetting;
			Instantiate(model.CharacterModel, transform, false);
		}
	}
}