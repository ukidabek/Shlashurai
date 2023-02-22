using System.Collections;
using System.Collections.Generic;
using MapGeneration.BaseGenerator;
using UnityEngine;

namespace MapGeneration.DungeonGenerator
{
    public class GenerateRoomListPhase : GenerationPhase
    {
        public override IEnumerator Generate(LevelGenerator generator)
		{
            var dungeonMetada = generator.GetMetaDataObject<DungeonMetadata>();
            dungeonMetada.RoomList.Clear();
            GenerateRoomList(dungeonMetada.StartRoom, dungeonMetada.RoomList);

            yield return new PauseYield(generator);

            _isDone = true;
        }

        private void GenerateRoomList(DungeonMetadata.RoomInfo startRoom, List<DungeonMetadata.RoomInfo> roomList)
        {
            roomList.Add(startRoom);

            for (int i = 0; i < startRoom.ConnectedRooms.Count; i++)
            {
                if (!roomList.Contains(startRoom.ConnectedRooms[i]))
                    GenerateRoomList(startRoom.ConnectedRooms[i], roomList);
            }
        }
    }
}