using Shlashurai.Characters;
using System.Collections.Generic;
using System.Linq;
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

	[SerializeField] private float m_additionalArmor = 0;

	[SerializeField] private ResourceHandler m_resourceChandler = null;

	private List<IArmor> m_armors = new List<IArmor>();

	public void ReceiveDamage(IDamage damage)
	{
		var damageAmount = damage.Amount - (m_armor + m_additionalArmor);
		if (damageAmount <= 0f) return;

		m_resourceChandler.Value -= damageAmount;
	}

	private void Reset() => m_resourceChandler.ResourceManager = GetComponent<ResourceManager>();

	public void AddArmor(IArmor armor)
	{ 
		if(m_armors.Contains(armor)) return;
		m_armors.Add(armor);
		CalculateAdditionalArmor();
	}

	public void RemoveArmor(IArmor armor)
	{
		if (m_armors.Contains(armor)) return;
		m_armors.Remove(armor);
		CalculateAdditionalArmor();
	}

	private void CalculateAdditionalArmor() => m_additionalArmor = m_armors.Sum(armor => armor.Value);
}
