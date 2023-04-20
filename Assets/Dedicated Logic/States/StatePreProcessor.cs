using UnityEngine;
using Utilities.ReferenceHost;
using Utilities.States;

namespace Shlashurai.States
{
	public class StatePreProcessor : MonoBehaviour, IStatePreProcessor
	{
		[SerializeField] private InjectionManager m_injectionManager = null;
		public void Process(IState state)
		{
			if (!(state is Component component)) return;
			var injectionPointCollection = component.GetComponent<InjectionPointCollection>();
			m_injectionManager.Inject(injectionPointCollection);
		}
	}
}