using UnityEngine;

using System.Collections;
using System.Collections.Generic;

using MapGeneration.BaseGenerator;

namespace MapGeneration.DungeonGenerator
{
    public class SelectStartRoomPhase : GenerationPhase
    {
        public override IEnumerator Generate(LevelGenerator generator)
		{
            var dungeonMetadata = generator.GetMetaDataObject<DungeonMetadata>();
            var layout = dungeonMetadata.LayoutData;

            List<Vector2Int> startPositionsList = new List<Vector2Int>();
            for (int i = 0; i < layout.RowsCount; i++)
            {
                if(layout.RowsCount == 0 || i == layout.RowsCount -1)
                    for (int j = 0; j < layout.ColumnsCount; j++)
                        startPositionsList.Add(new Vector2Int(i, j));
                else
                {
                    startPositionsList.Add(new Vector2Int(i, 0));
                    startPositionsList.Add(new Vector2Int(i, layout.ColumnsCount - 1));
                }
            }

            var startPositionIndex = Random.Range(0, startPositionsList.Count - 1);
			var startRoomPosition = startPositionsList[startPositionIndex];

            dungeonMetadata.StartRoom = new DungeonMetadata.RoomInfo(startRoomPosition, DungeonMetadata.RoomInfo.RoomType.Start);

            layout[startRoomPosition] = true;

            yield return new PauseYield(generator);

            _isDone = true;
        }
    }
}