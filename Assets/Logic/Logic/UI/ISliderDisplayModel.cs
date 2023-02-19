using System;

public interface ISliderDisplayModel
{
	float Percent { get; }
	event Action OnValueChanged;
}