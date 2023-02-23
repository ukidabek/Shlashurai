using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.States;

public class PauseStateLogic : StateLogic, ISwitchStateCondition
{
	[SerializeField] private InputValues m_inputValues = null;

	public bool Condition
	{
		get
		{
			if(m_inputValues.Pause)
			{
				m_inputValues.Pause = false;
				return true;
			}
			return false;
		}
	}
}
