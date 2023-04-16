using UnityEngine;
using Utilities.ReferenceHost;

public class Test : MonoBehaviour
{
#pragma warning disable CS0108, CS0414
	[SerializeField, Inject] private Rigidbody rigidbody = null;
	[SerializeField, Inject] private BoxCollider BoxCollider = null;
#pragma warning restore CS0108, CS0414
}
