using UnityEngine;

namespace Utilities.General
{
    [CreateAssetMenu(fileName = "AnimationParameter", menuName = "Utilities/AnimationParameter")]
    public class AnimatorParameterDefinition : AnimatorDefinitionBase
    {
        [SerializeField, HideInInspector] private string _name = string.Empty;
        [SerializeField, HideInInspector] private int _hash = 0;
        [Header("Set float settings")]
        [SerializeField] private bool m_useDampTime = false;
        [SerializeField] private float m_dampTime = 1.0f;
        
        public void SetInt(Animator animator, int value) => animator.SetInteger(_hash, value);
        public int GetInt(Animator animator) => animator.GetInteger(_hash);

        public void SetBool(Animator animator, bool value) => animator.SetBool(_hash, value);
        public bool GetBool(Animator animator) => animator.GetBool(_hash);

		public void SetFloat(Animator animator, float value)
		{
            if (m_useDampTime)
                animator.SetFloat(_hash, value, m_dampTime, Time.deltaTime);
            else
                animator.SetFloat(_hash, value);
		}

		public float GetFloat(Animator animator) => animator.GetFloat(_hash);

        public void SetTrigger(Animator animator) => animator.SetTrigger(_hash);
        public void ResetTrigger(Animator animator) => animator.ResetTrigger(_hash);
    }
}