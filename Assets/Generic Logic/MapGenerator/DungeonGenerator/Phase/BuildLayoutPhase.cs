using System.Collections;
using System.Collections.Generic;
using MapGeneration.BaseGenerator;
using UnityEngine;

namespace MapGeneration.DungeonGenerator.V2
{
	using Random = UnityEngine.Random;

	public class BuildLayoutPhase : GenerationPhase
    {
        private DungeonMetadata dungeonMetadata = null;
        private GenerationSettings settings = null;

        public override IEnumerator Generate(LevelGenerator generator)
		{
            dungeonMetadata = generator.GetMetaDataObject<DungeonMetadata>();
            settings = generator.GetMetaDataObject<GenerationSettings>();

            for (int i = 0; i < dungeonMetadata.RoomList.Count; i++)
            {
                BuildRoom(dungeonMetadata.RoomList[i], i, generator.transform).SetUpWall(dungeonMetadata.RoomList[i]);
                yield return new PauseYield(generator);
            }

            yield return new PauseYield(generator);

            _isDone = true;
        }

        private RoomSetup BuildRoom(DungeonMetadata.RoomInfo roomInfo, int index, Transform parent)
        {
            if(roomInfo.RoomObject != null)
                return roomInfo.RoomObject.GetComponent<RoomSetup>();

            GameObject roomPrefab = null;
            switch (roomInfo.Type)
            {
                case DungeonMetadata.RoomInfo.RoomType.Start:
                    roomPrefab = RandomizePrefab(settings.StartRoomGameObject);
                    break;
                case DungeonMetadata.RoomInfo.RoomType.Normal:
                case DungeonMetadata.RoomInfo.RoomType.Corridor:
                    roomPrefab = RandomizePrefab(settings.RoomGameObject);
                    break;
                case DungeonMetadata.RoomInfo.RoomType.End:
                    roomPrefab = RandomizePrefab(settings.EndRoomGameObject);
                    break;
            }

            var position = new Vector3(roomInfo.Position.y * settings.RoomSize.y, 0, roomInfo.Position.x * settings.RoomSize.x);

            roomInfo.RoomObject = Instantiate(roomPrefab, position, Quaternion.identity);
            roomInfo.RoomObject.name = string.Format("{0} {1}", index.ToString(), roomInfo.Type.ToString());

            roomInfo.RoomObject.transform.SetParent(parent);

            return roomInfo.RoomObject.GetComponent<RoomSetup>();
        }

        private GameObject RandomizePrefab(List<GameObject> roomPrefabList)
        {
            return roomPrefabList[Random.Range(0, roomPrefabList.Count)];
        }
    }
}