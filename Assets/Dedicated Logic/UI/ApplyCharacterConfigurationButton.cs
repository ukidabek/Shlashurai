using UnityEngine;
using Utilities.Events;

namespace Shlashurai.UI
{
	public class ApplyCharacterConfigurationButton : CharacterConfigurationButton
	{
		[SerializeField] protected ObjectEvent m_configurationSelected = null;

		protected override void OnButtonClick()
		{
			m_characterSelectionManager.ConfirmSelection();
			m_configurationSelected.Invoke();
		}
	}
}