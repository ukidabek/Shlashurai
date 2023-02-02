using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities.States
{
    public class OnFixedUpdateStateLogicExecutor : StateLogicExecutor
    {
        private IEnumerable<IOnFixUpdateLogic> _logic = new List<IOnFixUpdateLogic>();
        
        public override void ClearLogicToExecute()
        {
        }

        public override void SetLogicToExecute(IState state)
        {
            _logic = state.Logic.OfType<IOnFixUpdateLogic>();
        }

        private void Update()
        {
            var deltaTime = Time.fixedDeltaTime;
            foreach (var onUpdateLogic in _logic) 
                onUpdateLogic.OnFixUpdate(deltaTime);
        }
    }
}