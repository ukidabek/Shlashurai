using System;
using UnityEngine;
using Utilities.Configuration;

namespace Shlashurai.Character
{
	[Serializable]
	public class CharacterModelSetting : ISetting
	{
		[SerializeField] private GameObject m_characterModel = null;
		public GameObject CharacterModel => m_characterModel;
	}
}