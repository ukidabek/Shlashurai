using Shlashurai.Characters;
using UnityEngine;
using Weapons;

[RequireComponent(typeof(ResourceManager))]
public class Damagable : MonoBehaviour, IDamageable
{
	[SerializeField] private float m_armor = 0f;
	public float Armor
	{
		get => m_armor;
		set => m_armor = value;
	}

	[SerializeField] private ResourceHandler m_resourceChandler = null;

	public void ReceiveDamage(IDamage damage)
	{
		var damageAmount = damage.Amount - m_armor;
		if (damageAmount <= 0f) return;

		m_resourceChandler.Value -= damageAmount;
	}

	private void Reset() => m_resourceChandler.ResourceManager = GetComponent<ResourceManager>();
}
