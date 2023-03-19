using Progress;
using Shlashurai.Characters;
using UnityEngine;
using Weapons;

public class ExperienceDamageHandler : DamageHandler
{
	[SerializeField] private ResourceHandler m_resourceChandler = null;
	[SerializeField] protected float m_experience = 10f;

	private bool m_experienceGranted = false;

	private void OnEnable()
	{
		m_experienceGranted = false;
	}

	public override void OnDamage(IDamage damage)
	{
		if (m_experienceGranted ||
			m_resourceChandler.Value > 0)
			return;

		m_experienceGranted = true;
		
		var progressManager = damage.DamagingObject.GetComponent<ProgressManager>();
		
		if (progressManager == null) return;
		progressManager.AddExperience(m_experience);
	}
}
