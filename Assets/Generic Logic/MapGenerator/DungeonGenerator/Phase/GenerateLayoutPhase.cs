using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

using MapGeneration.BaseGenerator;

namespace MapGeneration.DungeonGenerator
{
    public class GenerateLayoutPhase : GenerateDungeonLayoutPhase
    {
        public override IEnumerator Generate(LevelGenerator generator)
		{
            GetReference(generator);

            var layout = dungeonMetadata.LayoutData;
            var currentRoom = dungeonMetadata.StartRoom;

            Vector2 currentPosition = dungeonMetadata.StartRoom.Position;
            Direction direction = GetDirection();
            int roomsInline = GetRoomCount();
            int roomToGenerate = settings.RoomToGenerate;
            bool isBloced = false;

            while(roomToGenerate > 0)
            {
                for (int i = 0; i < roomsInline; i++)
                {
                    if (CheckDirection(direction, currentPosition, layout))
                    {
                        AddRoom(ref currentPosition, direction, ref currentRoom, ref layout);
                        roomToGenerate--;
                    }
                    else
                    {
                        isBloced = CheckBlock(currentPosition, layout);
                        if (isBloced)
                            break;
                        i++;
                        direction = GetDirection();
                    }

                    yield return new PauseYield(generator);
                }

                if (isBloced)
                    break;
                direction = GetDirection();
                yield return new PauseYield(generator);
            }

            dungeonMetadata.EndRoom = currentRoom;
            currentRoom.Type = DungeonMetadata.RoomInfo.RoomType.End;

            _isDone = true;
        }
    }
}