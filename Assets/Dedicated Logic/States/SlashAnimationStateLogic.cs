using Shlashurai.Logic;
using UnityEngine;
using Utilities.General;

namespace Shlashurai.Player.Logic
{
	public class SlashAnimationStateLogic : OnCollisionEnterStateLogic
	{
		[SerializeField] private Animator m_animator = null;
		[SerializeField] private AnimatorParameterDefinition m_shashAnimationParameterDefinition = null;

        protected override CollisionHandlingMode CollisionHandling => CollisionHandlingMode.First;

		protected override void HandleCollision(Collision other) => m_shashAnimationParameterDefinition.SetTrigger(m_animator);
	}
}