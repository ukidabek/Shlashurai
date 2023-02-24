using System.Collections;
using MapGeneration.BaseGenerator;
using Unity.AI.Navigation;

namespace MapGeneration.DungeonGenerator.V3
{
	public class BakeNavMeshPhase : GenerationPhase
	{
		public override IEnumerator Generate(LevelGenerator generator)
		{
			var navMeshSurface = generator.GetComponent<NavMeshSurface>();
			navMeshSurface.BuildNavMesh();

			yield return new PauseYield(generator);

			_isDone = true;
		}
	}
}
