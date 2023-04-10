using Shlashurai.Player.Input;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
	public class PlayerAttackStateLogic : AttackStateLogic
	{
		[SerializeField] private InputValues m_inputValues = null;

		public override bool PerformAttack => m_inputValues.Attack;
	}
}