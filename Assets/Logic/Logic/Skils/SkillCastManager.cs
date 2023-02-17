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

		private ISkilCostManager m_skillCostManager = null;

		private void Awake()
		{
			m_skillCostManager = GetComponent<ISkilCostManager>();
		}

		public void Cast(ISkill skil)
		{
			if (m_skillCostManager.CanCast(skil.Cost) == false) return;

			var effects = skil.Effects;
			foreach (var effect in effects)
			{
				var coroutine = effect.Affect(this, m_target);
				if(coroutine != null)
					StartCoroutine(coroutine);
			}
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}
	}
}