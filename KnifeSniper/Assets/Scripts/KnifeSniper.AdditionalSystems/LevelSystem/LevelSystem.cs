using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.AdditionalSystems
{
    public class LevelSystem
    {
        private int currentLevel = 0;
        private int currentStage = 0;
        private int bestLevel;

        public void NextLevel()
        {
            currentLevel++;
            currentStage = ++currentStage > 5 ? 1 : currentStage;

            bestLevel = currentLevel > bestLevel ? currentLevel : bestLevel;
        }

        public int GetCurrentLevel()
        {
            return currentLevel;
        }

        public int GetCurrentStage()
        {
            return currentStage;
        }

        public int GetBestLevel()
        {
            return bestLevel;
        }

        public void ResetLevelValues()
        {
            currentLevel = 0;
            currentStage = 0;
        }
    } 
}
