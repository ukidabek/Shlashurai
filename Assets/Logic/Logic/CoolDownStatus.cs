using Shlashurai.Skill;
using System;

public class CoolDownStatus : ISkillStatus
{
	private float m_initialCoolDownTime = 0f;
	private float m_coolDownTime = 0f;

	public event Action<float> OnCoolDownChanged = null;

	public CoolDownStatus(float coolDownTime)
	{
		m_initialCoolDownTime = m_coolDownTime = coolDownTime;
	}

	public bool Tick(float deltaTime)
	{
		m_coolDownTime -= deltaTime;
		OnCoolDownChanged?.Invoke(1 - (m_coolDownTime / m_initialCoolDownTime));
		return m_coolDownTime <= 0f;
	}
}