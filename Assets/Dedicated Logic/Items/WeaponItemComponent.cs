using Shlashurai.Items;

public class WeaponItemComponent : IItemComponent
{
	public float MinDamage { get; }
	public float MaxDamage { get; }

	public WeaponItemComponent(float minDamage, float maxDamage)
	{
		MinDamage = minDamage;
		MaxDamage = maxDamage;
	}

	public float GetDamage() => UnityEngine.Random.Range(MinDamage, MaxDamage);
}