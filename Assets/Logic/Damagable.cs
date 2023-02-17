using Shlashurai.Characters;
using UnityEngine;
using Weapons;

[RequireComponent(typeof(ResourceManager))]
public class Damagable : MonoBehaviour, IDamageable
{
	[SerializeField] private ResourceChandler m_resourceChandler = null;

	public void ReceiveDamage(IDamage damage) => m_resourceChandler.Value -= damage.Amount;

	private void Reset() => m_resourceChandler.ResourceManager = GetComponent<ResourceManager>();
}
