using Shlashurai.Input;
using UnityEngine;
using Utilities.States;

public class PauseStateLogic : StateLogic, ISwitchStateCondition
{
	[SerializeField] private InputValues m_inputValues = null;

	public bool Condition => m_inputValues.Pause;

	public override void Deactivate()
	{
		base.Deactivate();
		m_inputValues.Pause = false;
	}
}
