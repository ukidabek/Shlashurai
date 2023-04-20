using Shlashurai.Character;
using UnityEngine;

namespace Shlashurai.States
{
	public class SlashDamageDealerStateLogic : OnCollisionEnterStateLogic
	{
		[SerializeField] private Transform m_model = null;
		[SerializeField] private DamageDealingHandler m_damageDealingHandler = new DamageDealingHandler();

		protected override CollisionHandlingMode CollisionHandling => CollisionHandlingMode.All;

		protected override void HandleCollision(Collision other)
		{
			var position = m_model.position;
			var forward = m_model.forward;
			m_damageDealingHandler.DealDamage(position, forward);
		}
	}
}