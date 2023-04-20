using System;
using UnityEngine;

namespace Shlashurai.UI
{
	public abstract class SliderDisplayModel : ISliderDisplayModel
	{
		[SerializeField] protected SliderDisplay m_display = null;

		public void Initialize()
		{
			PreProcess();
			m_display.Initialize(this);
		}

		protected abstract void PreProcess();

		public abstract float Percent { get; }

		public abstract event Action OnValueChanged;
	}
}