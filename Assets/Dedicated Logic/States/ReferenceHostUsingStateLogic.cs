using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public abstract class ReferenceHostUsingStateLogic<ReferenceHostType, ReferenceType> : StateLogic where ReferenceHostType : ReferenceHost<ReferenceType> where ReferenceType : Object
	{
		[SerializeField] protected ReferenceHostType m_referenceHost = null;
	}
}