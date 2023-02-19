using System.Collections;
using Utilities.General;

namespace Utilities.States
{
    public abstract class CoroutineStateLogicMonoBehaviour : StateLogic
    {
        protected CoroutineManager m_coroutineManager;

        protected virtual void Awake()
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