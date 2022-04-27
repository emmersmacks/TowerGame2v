using UnityEngine;
using game.level.generation.factory;
using System;
using System.Collections.Generic;

namespace game.level.generation
{
    public class PrefabsSpawner : MonoBehaviour
    {
        [SerializeField] private Cell CellPrefab;
        [SerializeField] private List<PrefabInform> prefabs = new List<PrefabInform>();

        private List<GameObject> instantiatedMazePlatforms = new List<GameObject>();
        private Vector3 CellSize = new Vector3(3, 3, 0);
        private Maze maze;

        public Maze GenerateMaze()
        {
            MazeGenerator generator = new MazeGenerator();
            maze = generator.GenerateMaze(GenerationSettings.columnNumber + 1, GenerationSettings.rowNumber + 1);


            for (int x = 0; x < maze.cells.GetLength(0); x++)
            {
                for (int y = 0; y < maze.cells.GetLength(1); y++)
                {
                    Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                    instantiatedMazePlatforms.Add(c.gameObject);

                    c.transform.localScale = CellSize;

                    c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
                    c.WallBottom.SetActive(maze.cells[x, y].WallBottom);
                }
            }
            return maze;
        }

        public List<GameObject> PrefabSpawn(MazeGeneratorCell[,] prefabMap)
        {
            List<GameObject> instantiatedPref = new List<GameObject>();
            for (int x = 0; x < prefabMap.GetLength(0); x++)
            {
                for (int y = 0; y < prefabMap.GetLength(1); y++)
                {
                    var cellType = prefabMap[x, y].cellType;
                    var backgroundCellType = prefabMap[x, y].backgroundType;

                    if (cellType != PrefabsType.none)
                    {
                        var pref = GetPrefab(cellType);
                        var gameObject = Instantiate(pref, new Vector3(x * CellSize.x + 1.5f, y * CellSize.y + 1.5f, y * CellSize.z), Quaternion.identity);
                        instantiatedPref.Add(gameObject);
                    }

                    if (backgroundCellType != PrefabsType.none)
                    {
                        var pref = GetPrefab(backgroundCellType);
                        var gameObject = Instantiate(pref, new Vector3(x * CellSize.x + 1.5f, y * CellSize.y + 1.5f, y * CellSize.z), Quaternion.identity);
                        instantiatedPref.Add(gameObject);
                    }
                }
            }
            return instantiatedPref;
        }

        public void SetExit(List<GameObject> gameObjectList)
        {
            foreach (var obj in gameObjectList)
            {
                if (obj.GetComponent<ExitAreaScript>())
                    GetComponent<SwitchLevelController>().AddListener(obj.GetComponent<ExitAreaScript>());
            }
        }

        public void DestroyCreatedPref(List<GameObject> objectsList)
        {
            foreach (var obj in objectsList)
            {
                Destroy(obj);
            }

            DestroyCreatedMaze();
        }

        public void DestroyCreatedMaze()
        {
            foreach (var obj in instantiatedMazePlatforms)
            {
                Destroy(obj);
            }
            instantiatedMazePlatforms.Clear();
        }

        private GameObject GetPrefab(PrefabsType type)
        {
            foreach (var obj in prefabs)
            {
                if (obj.prefabType == type)
                    return obj.gameObject;
            }

            return null;
        }
    }
}
