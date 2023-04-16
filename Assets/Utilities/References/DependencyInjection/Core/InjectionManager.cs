using System.Linq;
using UnityEngine;

namespace Utilities.ReferenceHost
{
	public class InjectionManager : MonoBehaviour
	{
		[SerializeField] private InjectionDictionary m_injectionDefinitionDictionary = new InjectionDictionary();

		public void Inject(InjectionPointCollection injectionPointSource)
			=> injectionPointSource.Inject(m_injectionDefinitionDictionary);

		[ContextMenu("GenerateInjectionDictionary")]
		public void GenerateInjectionDictionary()
		{
			var rootGameObject = transform.root.gameObject;
			var injectCollections = rootGameObject.GetComponentsInChildren<InjectionPointCollection>();
			var injectionDefinitions = m_injectionDefinitionDictionary.InjectDefinitions;
			//injectionDefinitions.Clear();

			foreach (var injectCollection in injectCollections)
			{
				var injectionPoints = injectCollection.InjectionPoints;
				foreach (var injectionPoint in injectionPoints)
				{
					var definition = injectionDefinitions.FirstOrDefault(def => def.IsEqual(injectionPoint));
					if (definition != null) continue;
					injectionDefinitions.Add(injectionPoint);
				}
			}
		}
	}
}