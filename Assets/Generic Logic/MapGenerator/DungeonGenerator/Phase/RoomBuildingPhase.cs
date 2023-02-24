using System.Collections;
using System.Linq;
using System.Text;
using MapGeneration.BaseGenerator;
using UnityEngine;

namespace MapGeneration.DungeonGenerator.V3
{
	public class RoomBuildingPhase : GenerationPhase
	{
		[SerializeField] private RoomSetup[] m_roomsPrefabs = null;

		private StringBuilder stringBuilder = new StringBuilder();

		public override IEnumerator Generate(LevelGenerator generator)
		{
			var dungeonMetadata = generator.GetMetaDataObject<DungeonMetadata>();
			var settings = generator.GetMetaDataObject<GenerationSettings>();

			var rooms = dungeonMetadata.RoomList;
			foreach (var room in rooms)
			{
				var directions = room.ConnectedRooms.Select(connectedRoom => GetDirection(room, connectedRoom));
				var selectedPrebasbs = m_roomsPrefabs
					.Where(roomPrefab => roomPrefab.Directions.Count() == directions.Count() && !roomPrefab.Directions.Except(directions).Any())
					.OrderBy(roomPrefab => Random.value);

				var count = selectedPrebasbs.Count();
				if(count == 0) 
				{
					stringBuilder.Clear();
					stringBuilder.Append("Prefab for handling directions: ");
					foreach (var direction in directions)
					{
						stringBuilder.Append($"{direction} ");
					}
					stringBuilder.Append("is missing!");
					Debug.Log(stringBuilder.ToString());

					continue;
				}

				var position = new Vector3(room.Position.y * settings.RoomSize.y, 0, room.Position.x * settings.RoomSize.x);

				var prefab = selectedPrebasbs.First();
				var roomInstance = Instantiate(prefab, position, Quaternion.identity);
				room.RoomObject = roomInstance.gameObject;
				roomInstance.transform.SetParent(generator.transform, false);

				yield return new PauseYield(generator);
			}

			yield return new PauseYield(generator);

			_isDone = true;
		}

		private Direction GetDirection(DungeonMetadata.RoomInfo info, DungeonMetadata.RoomInfo neighborInfo)
		{
			if (info.Position.x > neighborInfo.Position.x)
				return Direction.Down;
			if (info.Position.x < neighborInfo.Position.x)
				return Direction.Up;
			if (info.Position.y < neighborInfo.Position.y)
				return Direction.Right;
			if (info.Position.y > neighborInfo.Position.y)
				return Direction.Left;
			return Direction.Down;
		}
	}
}
