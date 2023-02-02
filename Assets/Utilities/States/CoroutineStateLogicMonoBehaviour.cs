using System.Collections;

namespace Utilities.States
{
    public abstract class CoroutineStateLogicMonoBehaviour : StateLogicMonoBehaviour
    {
        protected CoroutineManager m_coroutineManager;

        private void Awake()
        {
            m_coroutineManager = new CoroutineManager(this);
        }

        public override void Activate()
        {
            base.Activate();
            m_coroutineManager.Run(Coroutine());
        }

        public abstract IEnumerator Coroutine();
    }
}