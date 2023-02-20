using System.Collections;
using UnityEngine;
using Utilities.Containers;
using Utilities.General;

namespace Shlashurai.Containers
{
	public class ContainerAnimatorController : MonoBehaviour, IContainerAnimatorManager
	{
		[SerializeField] private Animator m_animator = null;
		[SerializeField] private AnimatorParameterDefinition m_isOpenAnimatorParameterDefinition = null;
		
		public IEnumerator Open()
		{
			m_isOpenAnimatorParameterDefinition.SetBool(m_animator, true);
			yield return new WaitForSeconds(1f);
		}
		
		public IEnumerator Close()
		{
			m_isOpenAnimatorParameterDefinition.SetBool(m_animator, false);
			yield return new WaitForSeconds(1f);
		}
	}
}