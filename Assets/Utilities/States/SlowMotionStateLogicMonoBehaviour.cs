using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Logic.States
{
    public class SlowMotionStateLogicMonoBehaviour : StateLogicMonoBehaviour
    {
        [SerializeField, Range(0, 2)] private float m_timeScale = 0.8f;
        [SerializeField] private float m_speed = 3f;
        
        private float timeScale = 1f;
        private float fixUpdateTimeScale = 1f;
        private Coroutine m_coroutine = null;

        [SerializeField] private UnityEvent<float> TimeScaleChanged = new UnityEvent<float>();

        public override void Activate()
        {
            base.Activate();
            timeScale = Time.timeScale;
            fixUpdateTimeScale = Time.fixedDeltaTime;
            
            RunCoroutine(m_timeScale, fixUpdateTimeScale * m_timeScale);
        }

        private void RunCoroutine(float timeScale, float fixedDeltaTime)
        {
            if(m_coroutine != null)
                StopCoroutine(m_coroutine);
            m_coroutine = StartCoroutine(SlowDownCoroutine(timeScale, fixedDeltaTime));
        }

        public override void Deactivate()
        {
            base.Deactivate();
            RunCoroutine(timeScale, fixUpdateTimeScale);
        }

        private IEnumerator SlowDownCoroutine(float timeScale, float fixedDeltaTime)
        {
            while (Time.timeScale != timeScale && Time.fixedDeltaTime != fixedDeltaTime)
            {
                var newTimeScale = Mathf.MoveTowards(Time.timeScale, timeScale, m_speed);
                Time.timeScale = newTimeScale;
                Time.fixedDeltaTime = fixUpdateTimeScale * Time.timeScale;
                TimeScaleChanged.Invoke(newTimeScale);
                yield return null;
            }
        }
    }
}