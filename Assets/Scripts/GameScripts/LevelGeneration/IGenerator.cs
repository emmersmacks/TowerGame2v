using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game.level.generation.factory
{
    public interface IGenerator
    {
        public MazeGeneratorCell[,] Generate(MazeGeneratorCell[,] afforablePosition);
    }
}

