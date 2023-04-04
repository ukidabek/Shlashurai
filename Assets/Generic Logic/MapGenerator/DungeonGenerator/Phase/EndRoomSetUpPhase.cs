using System.Collections;
using System.Linq;
using MapGeneration.BaseGenerator;
using UnityEngine;

namespace MapGeneration.DungeonGenerator.V3
{
	public class EndRoomSetUpPhase : GenerationPhase
	{
		[SerializeField] private GameObject[] m_endRoomPrefabs = null;

		public override IEnumerator Generate(LevelGenerator generator)
		{
			var dungeonMetadata = generator.GetMetaDataObject<DungeonMetadata>();
			var settings = generator.GetMetaDataObject<GenerationSettings>();

			var endRoom = m_endRoomPrefabs
				.OrderBy(prefab => Random.Range(float.MinValue, float.MaxValue))
				.FirstOrDefault();

			var room = dungeonMetadata.EndRoom;
			var position = new Vector3(room.Position.y * settings.RoomSize.y, 0, room.Position.x * settings.RoomSize.x);

			var instance = Instantiate(endRoom, generator.transform, false);
			instance.transform.position = position;

			yield return new PauseYield(generator);
			_isDone = true;
		}
	}
}
