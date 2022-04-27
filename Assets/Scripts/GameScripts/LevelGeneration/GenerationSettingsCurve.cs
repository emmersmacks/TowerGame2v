using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game.level.generation.factory
{
    public class GenerationSettingsCurve : MonoBehaviour
    {
        public AnimationCurve rowLevel;
        public AnimationCurve columnLevel;

        public AnimationCurve flyingEyeLevel;
        public AnimationCurve flyingEyeHPLevel;

        //public AnimationCurve chestCount;

        public void GenerateDataUpdate(int currentFloor)
        {
            GenerationSettings.rowNumber = (int)rowLevel.Evaluate(currentFloor);
            GenerationSettings.columnNumber = (int)columnLevel.Evaluate(currentFloor);

            GenerationSettings.flyingEyeNumber = (int)flyingEyeLevel.Evaluate(currentFloor);
            GenerationSettings.flyingEyeHP = (int)flyingEyeHPLevel.Evaluate(currentFloor);
        }
    }
}

