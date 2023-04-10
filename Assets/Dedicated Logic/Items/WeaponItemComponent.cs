using Shlashurai.Items;

public class WeaponItemComponent : IItemComponent
{
	public float MinDamage { get; }
	public float MaxDamage { get; }
	public float AttackInterval { get; }

	public WeaponItemComponent(float minDamage, float maxDamage, float attackInterval)
	{
		MinDamage = minDamage;
		MaxDamage = maxDamage;
		AttackInterval = attackInterval;
	}

	public float GetDamage() => UnityEngine.Random.Range(MinDamage, MaxDamage);
}
