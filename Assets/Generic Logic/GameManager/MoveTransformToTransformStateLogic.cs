using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

public class MoveTransformToTransformStateLogic : StateLogic
{
	[SerializeField] protected TransformReferenceHost m_transformToMove = null;
	[SerializeField] protected TransformReferenceHost m_targetTransform = null;

	public override void Activate()
	{
		base.Activate();
		var targetPosition = m_targetTransform.Instance.position;
		m_transformToMove.Instance.position = targetPosition;
	}
}
