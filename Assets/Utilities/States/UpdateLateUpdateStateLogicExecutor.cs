using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Logic.States
{
    public class UpdateLateUpdateStateLogicExecutor : StateLogicExecutor
    {
        private IEnumerable<IOnUpdateLogic> m_updateLogic;
        private IEnumerable<IOnLateUpdateLogic> m_lateUpdateLogic;

        public override void ClearLogicToExecute()
        {
            m_updateLogic = new List<IOnUpdateLogic>();
            m_lateUpdateLogic = new List<IOnLateUpdateLogic>();
        }

        public override void SetLogicToExecute(IState state)
        {
            var logic = state.Logic;
            m_updateLogic = logic.OfType<IOnUpdateLogic>();
            m_lateUpdateLogic = logic.OfType<IOnLateUpdateLogic>();
        }

        public void Update()
        {
            var deltaTime = Time.deltaTime;
            foreach (var onUpdateLogic in m_updateLogic) 
                onUpdateLogic.OnUpdate(deltaTime);
        }

        public void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            foreach (var lateUpdateLogic in m_lateUpdateLogic) 
                lateUpdateLogic.OnLateUpdate(deltaTime);
        }
    }
}