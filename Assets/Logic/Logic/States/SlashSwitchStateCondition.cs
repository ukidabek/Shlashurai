namespace Shlashurai.Player.Logic
{
    public class SlashSwitchStateCondition : OnInputSwitchStateCondition
    {
        public override bool Condition => m_inputStatus == m_values.Slash;
 
    }
}