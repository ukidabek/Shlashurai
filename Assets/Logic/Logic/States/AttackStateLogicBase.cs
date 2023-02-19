using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public abstract class AttackStateLogicBase : StateLogic
	{
		public abstract bool PerformingAttack { get; protected set; }
	}
}