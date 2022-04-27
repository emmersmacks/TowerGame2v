using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game.level.generation.factory
{
    class GeneratorFactory
    {
        public static IGenerator ProduceGenerate(GenerateFactoryType type)
        {
            switch(type)
            {
                case GenerateFactoryType.Chest: return new ChestGeneration ();
                case GenerateFactoryType.FlyingEye: return new FlyingEyeGenerator();
                case GenerateFactoryType.Torch: return new TorchGenerator();
                default: return null;
            }
        }
    }
}

