using UnityEngine;

namespace Utilities.General
{
    public class EnterExitBoolParameterSetter : StateMachineBehaviour
    {
        [SerializeField] private AnimatorParameterDefinition _animatorParameterDefinition;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animatorParameterDefinition.SetBool(animator, true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animatorParameterDefinition.SetBool(animator, false);
        }
    }
}