using System.Collections;
using MapGeneration.BaseGenerator;
using UnityEngine;

namespace MapGeneration.DungeonGenerator.V3
{
	public class StartEndRoomSetUpPhase : GenerationPhase
	{
		[SerializeField] private GameObject m_startPosition = null;
		public override IEnumerator Generate(LevelGenerator generator)
		{
			var dungeonMetadata = generator.GetMetaDataObject<DungeonMetadata>();
			var settings = generator.GetMetaDataObject<GenerationSettings>();

			var room = dungeonMetadata.StartRoom;
			var position = new Vector3(room.Position.y * settings.RoomSize.y, 0, room.Position.x * settings.RoomSize.x);

			var instance = Instantiate(m_startPosition, generator.transform, false);
			instance.transform.position = position;

			yield return new PauseYield(generator);
			_isDone = true;
		}
	}
}
