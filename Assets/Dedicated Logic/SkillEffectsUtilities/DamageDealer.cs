using Shlashurai.Character;
using UnityEngine;

namespace Shlashurai.Skills.Utilities
{
	public class DamageDealer : MonoBehaviour
	{
		[SerializeField] private DamageDealingHandler m_handler = new DamageDealingHandler();

		public void SetDamagingObject(GameObject damagingObject) => m_handler.DmagingObject = damagingObject;

		private void OnCollisionEnter(Collision collision)
		{
			var position = transform.position;
			var forward = transform.forward;
			m_handler.DealDamage(position, forward);
		}
	}
}