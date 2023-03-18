using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utilities.States
{
    public class SwitchStateStateLogic : StateLogic, IOnUpdateLogic
    {
        private enum ConditionMode { All, Any }

        [SerializeField] private ConditionMode _mode = ConditionMode.All;
        [SerializeField] private Object _stateMachineInstance = null;

        [SerializeField] private State _stateToEnter = null;
        
        [SerializeField] private Object[] _conditionsObjects = null;

        private IEnumerable<ISwitchStateCondition> _stateConditions = null;
        private IStateMachine m_stateMachine = null;
        [SerializeField] private bool m_returnOnEmpty = false;

        private bool Condition
        {
            get
            {
                var isEmpty = _stateConditions.Count() == 0;
				if (isEmpty) return m_returnOnEmpty;
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
            m_stateMachine = _stateMachineInstance as IStateMachine;
        }

        public override void Activate()
        {
			if (_stateConditions == null)
				_stateConditions = _conditionsObjects.OfType<ISwitchStateCondition>();
        }

        public virtual void OnUpdate(float deltaTime, float timeScale)
		{
            if (Condition) 
                Switch();
        }

		public void Switch()
		{
			var stateToEnter = _stateToEnter as IState;
			if (_stateToEnter == null || m_stateMachine.CurrentState == stateToEnter)
				return;
			m_stateMachine.EnterState(_stateToEnter);
		}

		public void GetStateMachineObject()
		{
            var root = transform.root.gameObject;
            var stateMachine = root.GetComponentInChildren<IStateMachine>();
            _stateMachineInstance = stateMachine as Object;
		}
	}
}