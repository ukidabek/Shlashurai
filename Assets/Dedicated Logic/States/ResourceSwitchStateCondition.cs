using Shlashurai.Characters;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Character
{
	public class ResourceSwitchStateCondition : SwitchStateConditionBase
	{
		public enum Mode
		{
			Less,
			LessOrEqual,
			Greater,
			GreaterOrEqual
		}

		[SerializeField] private ResourceHandler m_resourceChandler = null;
		[SerializeField] private float m_value = 10f;
		[SerializeField] private Mode m_mode = Mode.LessOrEqual;

		public override bool Condition
		{
			get
			{
				switch (m_mode)
				{
					case Mode.Less:
						return m_resourceChandler.Value < m_value;
					case Mode.LessOrEqual:
						return m_resourceChandler.Value <= m_value;
					case Mode.Greater:
						return m_resourceChandler.Value > m_value;
					case Mode.GreaterOrEqual:
						return m_resourceChandler.Value >= m_value;
					default:
						return false;
				}
			}
		}
	}
}