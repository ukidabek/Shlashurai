using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utilities.ReferenceHost
{
	[Serializable]
	public class InjectDefinition
	{
		[SerializeField] private string m_referenceID = string.Empty;
		public string ReferenceID => m_referenceID;
		public string ID => $"{m_referenceID}_{m_objectToInject.GetType().Name}";
		
		[SerializeField] private string m_typeName = string.Empty;

		[SerializeField] private Object m_objectToInject = null;
		public Object ObjectToInject => m_objectToInject;

		public InjectDefinition() { }

		public InjectDefinition(string id, Object objectToInject)
		{
			m_referenceID = id.Split('_').First();
			m_objectToInject = objectToInject;
			m_typeName = objectToInject.GetType().Name;
		}

		internal InjectDefinition(string id, string typeName)
		{
			m_referenceID = id.Split('_').First();
			m_typeName = typeName;
		}

		public bool IsEqual(InjectionPoint right) => ReferenceID == right.InjectionID && m_typeName == right.FieldTypeName;
	}
}