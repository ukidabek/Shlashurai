using UnityEngine;

namespace Shlashurai.Items
{
	public class SlotParentDefinitionCollectionProvider : MonoBehaviour
	{
		[SerializeField] private EquipmentManager m_equipmentManager = null;
		[SerializeField] private SlotParentDefinitionCollection m_slotParentDefinitionCollection = null;

		private void Awake() => SetParents();

		private void OnTransformChildrenChanged() => SetParents();

		private void SetParents()
		{
			m_slotParentDefinitionCollection = GetComponentInChildren<SlotParentDefinitionCollection>();
			if (m_slotParentDefinitionCollection == null) return;
			m_equipmentManager.SetTransformsForSlots(m_slotParentDefinitionCollection.SlotParentDefinitions);
		}
	}
}