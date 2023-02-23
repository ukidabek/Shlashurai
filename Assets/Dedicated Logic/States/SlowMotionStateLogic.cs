using System.Collections;
using UnityEngine;
using Utilities.General;
using Utilities.States;

namespace Shlashurai.Player.Logic
{
    public class SlowMotionStateLogic : StateLogic
    {
        [SerializeField, Range(0, 2)] private float m_timeScale = 0.8f;
        [SerializeField] private float m_speed = 3f;
        
        private float timeScale = 1f;
        private float fixUpdateTimeScale = 1f;

        private CoroutineManager m_coroutineManager = null;

		private void Awake()
		{
			m_coroutineManager = new CoroutineManager(this);
		}

		public override void Activate()
        {
            base.Activate();
            timeScale = Time.timeScale;
            fixUpdateTimeScale = Time.fixedDeltaTime;

            m_coroutineManager.Run(SlowDownCoroutine(m_timeScale, fixUpdateTimeScale * m_timeScale));
        }

        public override void Deactivate()
        {
            base.Deactivate();
			m_coroutineManager.Run(SlowDownCoroutine(timeScale, fixUpdateTimeScale));
		}

		private IEnumerator SlowDownCoroutine(float timeScale, float fixedDeltaTime)
        {
            while (Time.timeScale != timeScale && Time.fixedDeltaTime != fixedDeltaTime)
            {
                var newTimeScale = Mathf.MoveTowards(Time.timeScale, timeScale, m_speed);
                Time.timeScale = newTimeScale;
                Time.fixedDeltaTime = fixUpdateTimeScale * Time.timeScale;
                yield return null;
            }
        }
    }
}