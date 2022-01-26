using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.AdditionalSystems
{
    public class LevelSystem
    {
        private int currentLevel;

        public void NextLevel()
        {
            currentLevel++;
        }

        public int GetCurrentLevel()
        {
            return currentLevel;
        }
    } 
}
