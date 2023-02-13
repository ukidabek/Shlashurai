using Shlashurai.Characters;
using UnityEngine;
using Weapons;

namespace Shlashurai.Player.Logic
{
	[RequireComponent(typeof(ResourceManager))] 
	public class ResourceDepliter : MonoBehaviour, IDamageable
    {
		[SerializeField] private ResourceID m_resourceID;
		[SerializeField] private ResourceManager m_resourceManager;

		private Resource m_resource = null;

		private void Awake() => m_resource = m_resourceManager.GetResource(m_resourceID);

		public void ReceiveDamage(IDamage damage)
		{
			m_resource.CurrentValue -= damage.Amount;
		}

		private void Reset()
		{
			m_resourceManager = GetComponent<ResourceManager>();
		}
	}
}