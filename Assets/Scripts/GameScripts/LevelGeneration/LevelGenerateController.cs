using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game.level.generation.factory;

namespace game.level.generation
{
    public class LevelGenerateController : MonoBehaviour
    {
        MazeGeneratorCell[,] _mazeGeneratedMap;
        PrefabsSpawner _mazeSpawner;
        TilemapPainter _tilemapPainter;

        List<GameObject> instantiatedPrefabsList;
        

        private void Start()
        {
            _mazeSpawner = GetComponent<PrefabsSpawner>();
            _tilemapPainter = GetComponent<TilemapPainter>();
            GenerateNewLevel();
        }

        public void GenerateNewLevel()
        {
            Maze maze = _mazeSpawner.GenerateMaze();
            _mazeGeneratedMap = GeneratorFactory.ProduceGenerate(GenerateFactoryType.Chest).Generate(maze.cells);
            _mazeGeneratedMap = GeneratorFactory.ProduceGenerate(GenerateFactoryType.FlyingEye).Generate(_mazeGeneratedMap);
            _mazeGeneratedMap = GeneratorFactory.ProduceGenerate(GenerateFactoryType.Torch).Generate(_mazeGeneratedMap);

            instantiatedPrefabsList = _mazeSpawner.PrefabSpawn(_mazeGeneratedMap);
            _tilemapPainter.FilledBoxMap(GenerationSettings.columnNumber, GenerationSettings.rowNumber);
            _mazeSpawner.SetExit(instantiatedPrefabsList);
        }

        public void DeleteCreatedPrefab()
        {
            _mazeSpawner.DestroyCreatedPref(instantiatedPrefabsList);
            instantiatedPrefabsList.Clear();
        }
    }

    public enum PrefabsType
    {
        none,
        platform,
        obstacles,
        chest,
        exit,
        flyingEye,
        torch,
    }

    public enum GenerateFactoryType
    {
        Chest,
        FlyingEye,
        Torch
    }
}


