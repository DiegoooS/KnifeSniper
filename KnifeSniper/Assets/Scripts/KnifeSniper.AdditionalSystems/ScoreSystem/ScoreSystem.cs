using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.AdditionalSystems
{
    public class ScoreSystem
    {
        private int score;

        public void AddScore()
        {
            score++;
        }

        public int GetScore()
        {
            return score;
        }
    } 
}
