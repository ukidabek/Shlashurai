using System.Collections;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.Enemy.Logic
{
	public class DeathStateLogic : CoroutineStateLogic
    {
        [SerializeField] private float m_timeToDeactivate = 1f;
        [SerializeField] private GameObject m_objectToUnderactive = null; 
        
        public override IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(m_timeToDeactivate);
            m_objectToUnderactive.SetActive(false);
        }
    }
}