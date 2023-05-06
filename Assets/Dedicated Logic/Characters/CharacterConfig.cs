using System.Collections.Generic;
using UnityEngine;
using Utilities.Configuration;

namespace Shlashurai.Character
{
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