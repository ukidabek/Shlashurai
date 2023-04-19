using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shlashurai.Items
{
	public class SlotParentDefinition : MonoBehaviour
	{
		[SerializeField] private Object[] m_descriptors = null;
		public IEnumerable<IEquipmentDescriptor> Descriptors => m_descriptors.OfType<IEquipmentDescriptor>();
	}
}