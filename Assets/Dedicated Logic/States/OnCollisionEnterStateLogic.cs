using Shlashurai.Logic;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.States
{
	public abstract class OnCollisionEnterStateLogic : StateLogic
	{
		public enum CollisionHandlingMode
		{
			First,
			All
		}

		[SerializeField] protected abstract CollisionHandlingMode CollisionHandling { get; }
		[SerializeField] protected OnCollisionEnterHandler m_hitHandler = null;

		protected void OnControllerColliderHit(Collision other)
		{
			if (CollisionHandling == CollisionHandlingMode.First)
				m_hitHandler.OnControllerColliderHitCallback -= OnControllerColliderHit;

			HandleCollision(other);
		}

		protected abstract void HandleCollision(Collision other);

		public override void Activate()
		{
			base.Activate();
			m_hitHandler.OnControllerColliderHitCallback += OnControllerColliderHit;
		}

		public override void Deactivate()
		{
			base.Deactivate();
			m_hitHandler.OnControllerColliderHitCallback -= OnControllerColliderHit;
		}
	}
}