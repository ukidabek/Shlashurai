using Shlashurai.Player;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private ResourceManagerReferenceHost m_resourceManagerReferenceHost = null;
    [SerializeField] private ResourceDisplay[] resourceDisplays = null;

	private void Start()
	{
		var resourceManager = m_resourceManagerReferenceHost.Instance;
		foreach (var item in resourceDisplays)
			item.Initialize(resourceManager);
	}
}