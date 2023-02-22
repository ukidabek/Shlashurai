namespace MapGeneration.DungeonGenerator
{
	public partial class ObjectsPlacerPhase
	{
		public interface IObjectPlacerPhaseConfigurationProvider
		{
			ObjectPlacerPhaseConfiguration this[int key] { get; }
		}
	}
}