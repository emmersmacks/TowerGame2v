using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerGame.Game.Level.Generation.MazeControllers;

namespace TowerGame.Game.Level.Generation.Factory
{
    public class FlyingEyeGenerator : IGenerator
    {
        public MazeGeneratorCell[,] Generate(MazeGeneratorCell[,] mazeMap)
        {
            var afforablePos = GetAfforablePosition(mazeMap);
            for(int count = 0; count < GenerationSettings.flyingEyeNumber; count++)
            {
                var randomizeNumber = Random.Range(0, afforablePos.Count);
                var chestCell = afforablePos[randomizeNumber];
                afforablePos.RemoveAt(randomizeNumber);
                mazeMap[chestCell.X, chestCell.Y].cellType = PrefabsType.flyingEye;
            }
            
            return mazeMap;
        }

        private List<MazeGeneratorCell> GetAfforablePosition(MazeGeneratorCell[,] mazeMap)
        {
            List<MazeGeneratorCell> afforablePosition = new List<MazeGeneratorCell>();

            for (int x = 0; x < mazeMap.GetLength(0) - 1; x++)
            {
                for (int y = 0; y < mazeMap.GetLength(1) - 1; y++)
                {
                    if (y != 0 && x != 0)
                    {
                        if (!mazeMap[x, y].WallBottom && mazeMap[x, y].cellType == PrefabsType.none)
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

