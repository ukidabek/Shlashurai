using UnityEngine;

namespace Shlashurai.Items
{
	public class SlotParentDefinitionCollectionProvider : MonoBehaviour
	{
		[SerializeField] private EquipmentManager m_equipmentManager = null;
		[SerializeField] private SlotParentDefinition[] m_slotDefinitions = null;

		private void Awake() => SetParents();

		private void OnTransformChildrenChanged() => SetParents();

		private void SetParents()
		{
			m_slotDefinitions = GetComponentsInChildren<SlotParentDefinition>();
			if (m_slotDefinitions == null) return;
			m_equipmentManager.SetTransformsForSlots(m_slotDefinitions);
		}
	}
}