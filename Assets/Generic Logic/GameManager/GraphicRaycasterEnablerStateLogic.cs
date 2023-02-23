using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

public class GraphicRaycasterEnablerStateLogic : MonoBehaviour, IStateLogic, ISwitchStateCondition
{
	[SerializeField] private GraphicRaycastereReferenceHost m_graphicRaycastereReferenceHost = null;

	public bool Condition => m_graphicRaycastereReferenceHost.Instance != null && m_graphicRaycastereReferenceHost.Instance.enabled;

	public void Activate()
	{
		m_graphicRaycastereReferenceHost.OnReferenceChanged += Enable;
	}

	private void Enable()
	{
		if(m_graphicRaycastereReferenceHost.Instance == null) return;
		m_graphicRaycastereReferenceHost.Instance.enabled = true;
	}

	public void Deactivate()
	{
		m_graphicRaycastereReferenceHost.OnReferenceChanged -= Enable;
	}
}

