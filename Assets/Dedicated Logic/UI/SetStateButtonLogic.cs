using UnityEngine;
using Utilities.States;

namespace Shlashurai.UI
{
	public class SetStateButtonLogic : ButtonLogic
	{
		[SerializeField] protected StateDictionaryReferenceHost m_stateDictionaryReferenceHost = null;
		[SerializeField] protected StateID stateID = null;

		protected override void OnClickCallback() => m_stateDictionaryReferenceHost.Instance.SetState(stateID);
	}
}