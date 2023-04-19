using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Items
{
	public class SlotParentDefinitionCollection : MonoBehaviour
	{
		[SerializeField] private SlotParentDefinition[] m_slotParentDefinitions = null;
		public IEnumerable<SlotParentDefinition> SlotParentDefinitions => m_slotParentDefinitions;

		[ContextMenu("CollectSlotParentDefinition")]
		public void CollectSlotParentDefinition()
		{
			m_slotParentDefinitions = GetComponentsInChildren<SlotParentDefinition>();
		}
	}
}