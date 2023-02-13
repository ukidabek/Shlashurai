using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public abstract class AttackStateLogicBase : StateLogicMonoBehaviour
	{
		public abstract bool PerformingAttack { get; protected set; }
	}
}