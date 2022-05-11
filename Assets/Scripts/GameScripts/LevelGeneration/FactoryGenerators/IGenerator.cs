using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerGame.Game.Level.Generation.MazeControllers;


namespace TowerGame.Game.Level.Generation.Factory
{
    public interface IGenerator
    {
        public MazeGeneratorCell[,] Generate(MazeGeneratorCell[,] afforablePosition);
    }
}

