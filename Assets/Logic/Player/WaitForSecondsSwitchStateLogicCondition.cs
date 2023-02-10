using System.Collections;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Logic
{
	public class WaitForSecondsSwitchStateLogicCondition : CoroutineStateLogicMonoBehaviour, ISwitchStateCondition
	{
		[SerializeField] private float m_timeToWaint = 5f;

		private WaitForSeconds m_sleepTime;

		public bool Condition { get; private set; } = false;

		protected override void Awake()
		{
			base.Awake();
			m_sleepTime = new WaitForSeconds(m_timeToWaint);
		}

		public override void Activate()
		{
			Condition = false;
			base.Activate();
		}

		public override IEnumerator Coroutine()
		{
			yield return m_sleepTime;
			Condition = true;
		}
	}
}