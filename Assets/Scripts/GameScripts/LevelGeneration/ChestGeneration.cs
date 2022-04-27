using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game.level.generation.factory
{
    public class ChestGeneration :IGenerator
    {
        public MazeGeneratorCell[,] Generate(MazeGeneratorCell[,] mazeMap)
        {
            var afforablePos = GetAfforablePosition(mazeMap);
            if(afforablePos.Count > 0)
            {
                var chestCell = afforablePos[Random.Range(0, afforablePos.Count)];
                mazeMap[chestCell.X, chestCell.Y].cellType = PrefabsType.chest;
            }
            return mazeMap;
        }

        private List<MazeGeneratorCell> GetAfforablePosition(MazeGeneratorCell[,] mazeMap)
        {
            List<MazeGeneratorCell> afforablePosition = new List<MazeGeneratorCell>();

            for (int x = 0; x < mazeMap.GetLength(0); x++)
            {
                for (int y = 0; y < mazeMap.GetLength(1) - 1; y++)
                {
                    if (y != 0 && x != 0)
                    {
                        if (mazeMap[x, y].WallBottom && mazeMap[x, y].cellType == PrefabsType.none)
                        {
                            afforablePosition.Add(mazeMap[x, y]);
                        }
                    }
                }
            }

            return afforablePosition;
        }
    }
}

