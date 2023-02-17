using Shlashurai.Characters;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Character
{
	public class ConsumeResourceStateLogic : StateLogicMonoBehaviour
	{
		[SerializeField] private ResourceChandler m_resourceChandler = null;
		[SerializeField] private float m_consume = 10f;

		public override void Activate()
		{
			base.Activate();
			m_resourceChandler.Value -= m_consume;
		}
	}
}
