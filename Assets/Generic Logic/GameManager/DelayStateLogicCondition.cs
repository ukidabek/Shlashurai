using System.Collections;
using UnityEngine;
using Utilities.General;
using Utilities.States;

public class DelayStateLogicCondition : StateLogic, ISwitchStateCondition
{
	[SerializeField] private bool m_condition = false;
	public bool Condition => m_condition;

	[SerializeField] private float m_delay = 3f;

	private CoroutineManager m_coroutineManager = null;

	public override void Activate()
	{
		base.Activate();
		m_condition = false;

		if (m_coroutineManager == null)
			m_coroutineManager = new CoroutineManager(this, DelayCoroutine());

		m_coroutineManager.Run();
	}

	private IEnumerator DelayCoroutine()
	{
		yield return new WaitForSeconds(m_delay);
		m_condition = true;
	}
}