namespace Shlashurai.Skill
{
	public interface ISkilCostManager
	{
		bool CanCast(ISkill skill);
		void ApplyCost();
	}
}