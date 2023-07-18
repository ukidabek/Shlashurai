namespace Shlashurai.States
{
	public class AimSwitchStateCondition : OnInputSwitchStateCondition
	{
		public override bool Condition => m_inputStatus == m_values.Aim;
	}
}