using UnityEngine;
using UnityEngine.UI;

public class SliderDisplay : MonoBehaviour
{
    [SerializeField] private Slider m_slider = null;

    ISliderDisplayModel m_displayModel = null;

	public void Initialize(ISliderDisplayModel displayModel)
    {
		(m_displayModel = displayModel).OnValueChanged += OnValueChangedCallback;
    }

    private void OnDestroy()
    {
        if (m_displayModel == null) return;
		m_displayModel.OnValueChanged -= OnValueChangedCallback;
    }

    private void OnValueChangedCallback() => m_slider.value = m_displayModel.Percent;
}

