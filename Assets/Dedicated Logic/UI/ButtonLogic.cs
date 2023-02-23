using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonLogic : MonoBehaviour
{
	[SerializeField] private Button m_button = null;

	void Awake() => m_button.onClick.AddListener(OnClickCallback);

	private void OnDestroy() => m_button.onClick.RemoveListener(OnClickCallback);

	protected abstract void OnClickCallback();

	private void Reset()
	{
		m_button = GetComponent<Button>();
	}
}
