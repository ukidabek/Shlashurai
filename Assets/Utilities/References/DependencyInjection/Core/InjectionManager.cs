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
			var baseInjectionDefinitionsList = m_injectionDefinitionDictionary
				.InjectDefinitions
				.Where(injector => injector.Lock)
				.ToList();

			foreach (var injectCollection in injectCollections)
			{
				var injectionPoints = injectCollection.InjectionPoints;
				foreach (var injectionPoint in injectionPoints)
				{
					var definition = baseInjectionDefinitionsList.FirstOrDefault(def => def.IsEqual(injectionPoint));
					if (definition != null) continue;
					baseInjectionDefinitionsList.Add(injectionPoint);
				}
			}

			var InjectDefinitions = m_injectionDefinitionDictionary.InjectDefinitions;
			InjectDefinitions.Clear();
			InjectDefinitions.AddRange(baseInjectionDefinitionsList);
		}
	}
}