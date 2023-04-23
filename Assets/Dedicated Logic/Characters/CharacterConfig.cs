using System;
using System.Collections.Generic;
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

	[CreateAssetMenu(menuName = "Configuration/CharacterConfiguration", fileName = "CharacterConfiguration")]
	public class CharacterConfig : Config
	{
		[SerializeField] private CharacterModelSetting m_characterModel = null;
		
		private ISetting[] m_settings = null;
		public override IEnumerable<ISetting> Settings => m_settings;

		private void OnEnable()
		{
			m_settings = new[]
			{
				m_characterModel,
			};
		}
	}
}