using Shlashurai.Characters;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.States
{
	public class ConsumeResourceStateLogic : StateLogic
	{
		[SerializeField] private ResourceHandler m_resourceChandler = null;
		[SerializeField] private float m_consume = 10f;

		public override void Activate()
		{
			base.Activate();
			m_resourceChandler.Value -= m_consume;
		}
	}
}
