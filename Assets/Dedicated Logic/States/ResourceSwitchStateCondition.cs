using Shlashurai.Characters;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Character
{
	public class ResourceSwitchStateCondition : SwitchStateConditionBase
	{
		[SerializeField] private ResourceHandler m_resourceChandler = null;

		[SerializeField] private float m_minimumValue = 10f;

		public override bool Condition => m_resourceChandler.Value >= m_minimumValue;
	}
}
