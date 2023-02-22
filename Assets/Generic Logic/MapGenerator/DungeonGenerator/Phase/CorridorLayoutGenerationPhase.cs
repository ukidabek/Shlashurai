using System.Collections;
using System.Collections.Generic;
using MapGeneration.BaseGenerator;
using UnityEngine;

namespace MapGeneration.DungeonGenerator
{
    public class CorridorLayoutGenerationPhase : GenerateDungeonLayoutPhase
    {
        private List<int> usedIndexes = new List<int>();

        public override IEnumerator Generate(LevelGenerator generator)
		{
            GetReference(generator);
            int corridorsToGenerate = Random.Range(settings.MinCorridorsToGenerate, settings.MaxCorridorsToGenerate);

            Debug.LogFormat("{0} corridors to generate.", corridorsToGenerate);

            var roomList = dungeonMetadata.RoomList;
            var currentRoom = GetRoom(roomList);
            var currentPosition = currentRoom.Position;
            var layout = dungeonMetadata.LayoutData;

            Direction direction = GetDirection();
            while (corridorsToGenerate > 0)
            {
                int corridorLength = Random.Range(settings.MinCorridorsToLenght, settings.MaxCorridorsToLenght);
                while (corridorLength > 0)
                {
                    if (CheckDirection(direction, currentPosition, layout))
                    {
                        AddRoom(ref currentPosition, direction, ref currentRoom, ref layout, DungeonMetadata.RoomInfo.RoomType.Corridor);
                        direction = GetDirection();
                        corridorLength--;
                    }
                    else
                    {
                        if (CheckBlock(currentPosition, layout))
                            break;
                        else
                            direction = GetDirection();
                    }

                    yield return new PauseYield(generator);
                }

                --corridorsToGenerate;
                currentRoom = GetRoom(roomList);
                currentPosition = currentRoom.Position;
                yield return new PauseYield(generator);
            }

            yield return new PauseYield(generator);

            _isDone = true;
        }

        protected DungeonMetadata.RoomInfo GetRoom(List<DungeonMetadata.RoomInfo> rooms)
        {
            int index = Random.Range(1, rooms.Count - 1);
            while(usedIndexes.Contains(index))
                index = Random.Range(1, rooms.Count - 1);
            
            usedIndexes.Add(index);

            return rooms[index];
        }
    }
}