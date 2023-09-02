namespace Skills
{
	public interface ISkilCostManager
	{
		bool CanCast(ISkill skill);
		void ApplyCost();
	}
}