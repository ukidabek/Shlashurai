using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utilities.ReferenceHost
{
	public abstract class ReferenceHostInjector<ReferenceHostType, Type> : MonoBehaviour
		where ReferenceHostType : ReferenceHost<Type>
		where Type : Object
	{
        [SerializeField] private Object m_injectionObject = null;
		[SerializeField] private ReferenceHostType m_reference = null;

        private FieldInfo m_fieldInfo = null;

        private const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

		private void Awake()
		{
            var objectType = m_injectionObject.GetType();
            var fields = objectType.GetFields(bindingFlags);
            var type = typeof(Type);
            m_fieldInfo = fields
                .Where(field => field.FieldType == type)
                .FirstOrDefault(field => field.GetCustomAttribute<InjectAttribute>() != null);

			m_reference.OnReferenceChanged += OnReferenceChanged;
            if (m_reference.Instance == null) return;
            OnReferenceChanged();
		}

		private void OnReferenceChanged()
		{
            if(m_fieldInfo != null)
                m_fieldInfo.SetValue(m_injectionObject, m_reference.Instance);
        }

		private void OnDisable() => m_reference.OnReferenceChanged -= OnReferenceChanged;
	}
}