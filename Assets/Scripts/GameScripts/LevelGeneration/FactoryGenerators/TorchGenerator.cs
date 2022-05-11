using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerGame.Game.Level.Generation.MazeControllers;


namespace TowerGame.Game.Level.Generation.Factory
{
    public class TorchGenerator : IGenerator
    {
        public MazeGeneratorCell[,] Generate(MazeGeneratorCell[,] afforablePosition)
        {
            var afforablePos = GetAfforablePosition(afforablePosition);
            for (int i = 0; i < afforablePos.Count; i++)
            {
                var pos = afforablePos[i];
                afforablePosition[pos.X, pos.Y].backgroundType = PrefabsType.torch;
                Debug.Log("Generate torch");
            }
        
            return afforablePosition;
        }

        private List<MazeGeneratorCell> GetAfforablePosition(MazeGeneratorCell[,] mazeMap)
        {
            List<MazeGeneratorCell> afforablePosition = new List<MazeGeneratorCell>();

            for (int x = 0; x < mazeMap.GetLength(0) - 1; x = x + 2)
            {
                for (int y = 0; y < mazeMap.GetLength(1) - 1; y++)
                {
                    afforablePosition.Add(mazeMap[x, y]);
                }
            }

            return afforablePosition;
        }
    }
}

