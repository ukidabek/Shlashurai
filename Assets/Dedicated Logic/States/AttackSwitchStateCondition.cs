namespace Shlashurai.States
{
	public class AttackSwitchStateCondition : OnInputSwitchStateCondition
	{
		public override bool Condition => m_inputStatus == m_values.Attack;
		protected override void Reset()
		{
			m_values.Attack = false;
		}
	}
}