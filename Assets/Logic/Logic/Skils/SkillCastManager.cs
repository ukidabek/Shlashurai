using UnityEngine;

namespace Shlashurai.Skil
{
	public class SkillCastManager : MonoBehaviour
	{
		[SerializeField] private GameObject m_target = null;
		
		private ISkilCostManager m_skillCostManager = null;

		private void Awake()
		{
			m_skillCostManager = GetComponent<ISkilCostManager>();
		}

		public void SetTarget(GameObject target) => m_target = target;

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