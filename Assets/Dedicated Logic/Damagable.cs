using Shlashurai.Characters;
using UnityEngine;
using Weapons;

[RequireComponent(typeof(ResourceManager))]
public class Damagable : MonoBehaviour, IDamageable
{
	[SerializeField] private DamageHandler[] m_handlers = null;

	public void ReceiveDamage(IDamage damage)
	{
		foreach (var handler in m_handlers) 
			handler.OnDamage(damage);
	}
}
