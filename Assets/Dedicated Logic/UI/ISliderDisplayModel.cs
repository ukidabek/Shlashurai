using System;

namespace Shlashurai.UI
{
	public interface ISliderDisplayModel
	{
		float Percent { get; }
		event Action OnValueChanged;
	}
}