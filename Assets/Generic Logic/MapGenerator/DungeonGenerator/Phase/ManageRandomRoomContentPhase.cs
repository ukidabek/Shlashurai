using System.Collections;
using MapGeneration.BaseGenerator;

namespace MapGeneration.DungeonGenerator.V3
{
	public class ManageRandomRoomContentPhase : GenerationPhase
	{
		public override IEnumerator Generate(LevelGenerator generator)
		{
			var dungeonMetadata = generator.GetMetaDataObject<DungeonMetadata>();
			var rooms = dungeonMetadata.RoomList;

			foreach (var room in rooms ) 
			{
				
				var randomObjects = room.RoomObject.GetComponentsInChildren<RandomRoomContent>();

				if(dungeonMetadata.StartRoom == room)
					foreach (var randomObject in randomObjects)
						randomObject.ForceOff();
				else
					foreach (var randomObject in randomObjects)
						randomObject.Randomize();

				yield return new PauseYield(generator);
			}

			yield return new PauseYield(generator);
			_isDone = true;
		}
	}
}
