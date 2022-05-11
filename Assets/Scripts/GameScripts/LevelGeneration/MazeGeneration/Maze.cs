using UnityEngine;
using TowerGame.Game.Level.Generation;

namespace TowerGame.Game.Level.Generation.MazeControllers
{
    public class Maze
    {
        public MazeGeneratorCell[,] cells;
        public Vector2Int finishPosition;
    }

    public class MazeGeneratorCell
    {
        public int X;
        public int Y;

        public bool WallLeft = true;
        public bool WallBottom = true;

        public PrefabsType cellType = PrefabsType.none;
        public PrefabsType backgroundType = PrefabsType.none;

        public bool Visited = false;
        public int DistanceFromStart;
    }
}

