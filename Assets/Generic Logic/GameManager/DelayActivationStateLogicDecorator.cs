using System.Collections;
using UnityEngine;
using Utilities.General;
using Utilities.States;

public class DelayActivationStateLogicDecorator : StateLogic
{
	[SerializeField] private StateLogic m_innerStateLogic = null;
	[SerializeField] private float m_delay = 3f;

	private CoroutineManager m_coroutineManager = null;

	public override void Activate()
	{
		base.Activate();
		if (m_coroutineManager == null)
			m_coroutineManager = new CoroutineManager(this, DelayCoroutine());

		m_coroutineManager.Run();
	}

	public override void Deactivate()
	{
		base.Deactivate();
		m_innerStateLogic.Deactivate();
	} 

	private IEnumerator DelayCoroutine()
	{
		yield return new WaitForSeconds(m_delay);
		m_innerStateLogic.Activate();
	}
}
