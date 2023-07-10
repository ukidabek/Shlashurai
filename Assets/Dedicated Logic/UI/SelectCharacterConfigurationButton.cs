using Shlashurai.Character;
using System.Linq;
using TMPro;
using UnityEngine;
using Utilities.Configuration;

namespace Shlashurai.UI
{
	public class SelectCharacterConfigurationButton : CharacterConfigurationButton
	{
		[SerializeField] private Config m_config = null;
		[SerializeField] private TMP_Text m_text = null;

		public void Initialize(Config config)
		{
			m_config = config;
			m_text.text = config.Settings
				.OfType<Name>()
				.FirstOrDefault();
		}

		protected override void OnButtonClick() => m_characterSelectionManager.SelectConfig(m_config);
	}
}