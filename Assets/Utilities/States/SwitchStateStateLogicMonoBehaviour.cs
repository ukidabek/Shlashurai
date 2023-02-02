using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utilities.States
{
    public class SwitchStateStateLogicMonoBehaviour : StateLogicMonoBehaviour, IOnUpdateLogic
    {
        private enum ConditionMode { All, Any }

        private StateSwitcher _stateSwitcher = null;
        
        [SerializeField] private ConditionMode _mode = ConditionMode.All;
        [SerializeField] private Object _stateMachineInstance = null;

        [SerializeField] private State _stateToEnter = null;
        
        [SerializeField] private Object[] _conditionsObjects = null;
        private IEnumerable<ISwitchStateCondition> _stateConditions = null;

        private bool Condition
        {
            get
            {
                return _mode switch
                {
                    ConditionMode.All => _stateConditions.All(condition => condition.Condition),
                    ConditionMode.Any => _stateConditions.Any(condition => condition.Condition),
                    _ => false
                };
            }
        }

        private void Awake()
        {
            _stateSwitcher = new StateSwitcher(_stateMachineInstance, _stateToEnter);
            _stateConditions = _conditionsObjects.OfType<ISwitchStateCondition>();
        }

        public override void Activate()
        {
            foreach (var switchStateCondition in _stateConditions) 
                switchStateCondition.Activate();
        }

        public override void Deactivate()
        {
            foreach (var switchStateCondition in _stateConditions)
                switchStateCondition.Deactivate();
        }

        public virtual void OnUpdate(float deltaTime)
        {
            if (Condition) 
                _stateSwitcher.Switch();
        }
    }
}