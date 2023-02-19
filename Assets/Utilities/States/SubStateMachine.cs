using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities.States
{
    public class SubStateMachine : StateLogic, IStateMachine, IOnUpdateLogic, IOnFixUpdateLogic, IOnLateUpdateLogic, IStateLogicExecutor
    {
        [SerializeField] private State _currentState = null;
        public IState CurrentState => _currentState;
        
        private IEnumerable<IOnUpdateLogic> _currentStateOnUpdateLogic = null;
        private IEnumerable<IOnFixUpdateLogic> _currentStateOnFixUpdateLogic = null;
        private IEnumerable<IOnLateUpdateLogic> _currentStateOnLateUpdateLogic = null;
        
        [SerializeField] private StateTransitionLogicBase[] _transition;
        
        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine(new[] {this}, _transition);
            _stateMachine.OnStateChange += StateMachineOnOnStateChange;
        }

        public override void Activate() => CurrentState?.Enter();

        public override void Deactivate() => CurrentState?.Exit();

        private void StateMachineOnOnStateChange()
        {
            if (_stateMachine.CurrentState is State state)
                _currentState = state;
        }

        public void EnterState(IState statToEnter) => _stateMachine.EnterState(statToEnter);

        public void OnUpdate(float deltaTime, float timeScale)
		{
            foreach (var onUpdateLogic in _currentStateOnUpdateLogic) 
                onUpdateLogic.OnUpdate(deltaTime, timeScale);
        }

        public void OnFixUpdate(float deltaTime, float timeScale)
		{
            foreach (var onUpdateLogic in _currentStateOnFixUpdateLogic) 
                onUpdateLogic.OnFixUpdate(deltaTime, timeScale);
        }

        public void OnLateUpdate(float deltaTime, float timeScale)
		{
            foreach (var onUpdateLogic in _currentStateOnLateUpdateLogic) 
                onUpdateLogic.OnLateUpdate(deltaTime, timeScale);
        }

        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }
        
        public void ClearLogicToExecute()
        {
        }

        public void SetLogicToExecute(IState state)
        {
            var logic = state.Logic;
            _currentStateOnUpdateLogic = logic.OfType<IOnUpdateLogic>();
            _currentStateOnFixUpdateLogic = logic.OfType<IOnFixUpdateLogic>();
            _currentStateOnLateUpdateLogic = logic.OfType<IOnLateUpdateLogic>();
        }
    }
}