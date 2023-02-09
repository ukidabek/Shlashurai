using UnityEngine;
using Utilities.States;
using Weapons;

namespace Shlashurai.Player.Logic
{
    public class SlashDamageDealerStateLogic : StateLogicMonoBehaviour
    {
        [SerializeField] private OnCollisionEnterHandler m_hitHandler = null;
        [SerializeField] private float m_radius = 5f;
        [SerializeField] private Transform m_model = null;

		[SerializeField] private DamageDealingHandler m_damageDealingHandler = new DamageDealingHandler();


        
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

        private void OnControllerColliderHit(Collision obj)
        {
			var position = m_model.position;
			var forward = m_model.forward;
			m_damageDealingHandler.DealDamage(position, forward);
        }
    }
}