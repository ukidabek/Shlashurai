using System;
using System.Collections;
using UnityEngine;

namespace Shlashurai.Skill
{
	public class SkillCastManager : MonoBehaviour
	{
		[SerializeField] private GameObject m_target = null;
		public GameObject Target
		{
			get => m_target;
			set => m_target = value;
		}

		[SerializeField] private Transform m_skillSpawnPoint = null;
		public Transform SkillSpawnPoint => m_skillSpawnPoint;

		[SerializeField] private bool m_casting = false;
		public bool Casting => m_casting;

		private ISkilCostManager m_skillCostManager = null;

		public event Action<ISkill> OnSkillCastBegin = null;
		public event Action<float> OnSkillCastProgress = null;
		public event Action<ISkill> OnSkillCastEnd = null;

		private Coroutine m_coroutine = null;

		private void Awake()
		{
			m_skillCostManager = GetComponent<ISkilCostManager>();
		}

		public void Cast(ISkill skill)
		{
			if (m_skillCostManager.CanCast(skill) == false)
				return;

			if(m_coroutine != null)
				StopCoroutine(m_coroutine);

			m_coroutine = StartCoroutine(CastCoroutine(skill));
		}

		private void HandleEffects(ISkill skill, SkillCastManager skillCastManager, GameObject target)
		{
			var effects = skill.Effects;
			foreach (var effect in effects)
				effect.Affect(skillCastManager, target);
		}

		private IEnumerator CastCoroutine(ISkill skill)
		{
			var skillConst = skill.Cost;
			var castTime = skillConst.CastTime;
			var counter = castTime;

			OnSkillCastBegin?.Invoke(skill);
			m_casting = true;

			while (counter > 0) 
			{
				counter -= Time.deltaTime;
				OnSkillCastProgress?.Invoke(1 - (counter / castTime));
				yield return null;
			}

			HandleEffects(skill, this, Target);

			m_skillCostManager.ApplyCost();

			m_casting = false;
			OnSkillCastEnd?.Invoke(skill);
		}
	}
}