namespace Logic.Items
{
    public interface IItem
    {
        string Name { get; }
        string DisplayName { get; }
        bool IsStackable { get; }
    }
}