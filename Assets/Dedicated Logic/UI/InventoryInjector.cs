using Shlashurai.Player;
using UnityEngine;

public class InventoryInjector : MonoBehaviour
{
	[SerializeField] private InventoryManagerReferenceHost m_inventoryManger = null;
	[SerializeField] private InventoryDisplay m_inventoryDisplay = null;

	private void Awake()
	{
		m_inventoryManger.OnReferenceChanged += OnReferenceChanged;
	}

	private void OnReferenceChanged()
	{
		m_inventoryDisplay.Initialize(m_inventoryManger.Instance);
	}
}