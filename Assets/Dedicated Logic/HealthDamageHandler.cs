using Shlashurai.Characters;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Weapons;

public class HealthDamageHandler : DamageHandler
{
	private List<IArmor> m_armors = new List<IArmor>();

	[SerializeField] private float m_armor = 0f;
	public float Armor
	{
		get => m_armor;
		set => m_armor = value;
	}

	[SerializeField] private float m_additionalArmor = 0;

	[SerializeField] private ResourceHandler m_resourceChandler = null;

	public override void OnDamage(IDamage damage)
	{
		var damageAmount = damage.Amount - (m_armor + m_additionalArmor);
		if (damageAmount <= 0f) return;

		m_resourceChandler.Value -= damageAmount;
	}

	public void AddArmor(IArmor armor)
	{
		if (m_armors.Contains(armor)) return;
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
