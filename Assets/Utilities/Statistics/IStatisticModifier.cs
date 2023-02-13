namespace Shlashurai.Statistics
{
    public interface IStatisticModifier
    {
        int Order { get; }
        float Apply(float value);
    }
}