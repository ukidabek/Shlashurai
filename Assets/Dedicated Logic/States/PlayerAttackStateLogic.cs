using Shlashurai.Input;
using UnityEngine;

namespace Shlashurai.States
{
	public class PlayerAttackStateLogic : AttackStateLogic
	{
		[SerializeField] private InputValues m_inputValues = null;

		public override bool PerformAttack => m_inputValues.Attack;
	}
}