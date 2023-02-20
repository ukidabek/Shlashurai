using UnityEngine;

public class SliderDisplayInitializer : MonoBehaviour
{
    [SerializeField] private ResourceSliderDisplayModel m_sliderDisplayModel = null;

	private void Start()
	{
		m_sliderDisplayModel.Initialize();
	}
}