using UnityEngine;
using Weapons;

public abstract class DamageHandler : MonoBehaviour
{
	public abstract void OnDamage(IDamage damage);
}
