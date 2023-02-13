using UnityEngine;
using Utilities.States;
using Utilities.Values;

namespace Shlashurai.Player.Logic
{
	public class SlashDirectionDisplayStateLogic : StateLogicMonoBehaviour, IOnUpdateLogic
    {
        [SerializeField] private Transform m_root = null;
        [SerializeField] private LineRenderer m_lineRenderer = null;
        [SerializeField] private FloatValue m_range = null;
        [SerializeField] private float m_expandSpeed = 3f;

        private Vector3[] m_points = null;
        private float m_scale = 0f;
        private void OnEnable() => m_points = new Vector3[2];

        public override void Activate()
        {
            base.Activate();
            m_scale = 0f;
            CalculatePoints();
            m_lineRenderer.enabled = true;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            m_lineRenderer.enabled = false;
        }

        public void OnUpdate(float deltaTime, float timeScale)
		{
            m_scale = Mathf.MoveTowards(m_scale, 1f, m_expandSpeed);
            CalculatePoints();
        }

        private void CalculatePoints()
        {
            m_points[0] = m_root.position + Vector3.up * .1f;
            m_points[1] = m_points[0] + m_root.forward * (m_range * m_scale);

            m_lineRenderer.SetPositions(m_points);
        }
    }
}