using Shlashurai.Character;
using UnityEngine;
using UnityEngine.UI;
using Utilities.ReferenceHost;

namespace Shlashurai.UI
{
	public abstract class CharacterConfigurationButton : MonoBehaviour
	{
		[SerializeField, Inject] protected CharacterSelectionManager m_characterSelectionManager = null;
		[SerializeField] protected Button m_button = null;

		protected virtual void Awake() => m_button.onClick.AddListener(OnButtonClick);

		protected abstract void OnButtonClick();
	}
}