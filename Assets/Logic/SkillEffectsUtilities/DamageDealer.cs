using Shlashurai.Player.Logic;
using UnityEngine;

namespace Logic.SkillEffectsUtilities
{
	public class DamageDealer : MonoBehaviour
	{
		[SerializeField] private DamageDealingHandler m_handler = new DamageDealingHandler();


		private void OnCollisionEnter(Collision collision)
		{
			var position = transform.position;
			var forward = transform.forward;
			m_handler.DealDamage(position, forward);
		}
	}
}