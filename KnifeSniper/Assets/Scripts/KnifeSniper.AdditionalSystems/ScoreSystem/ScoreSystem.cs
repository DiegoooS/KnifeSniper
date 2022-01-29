using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.AdditionalSystems
{
    public class ScoreSystem
    {
        private int score;
        private int bestScore;

        public void AddScore()
        {
            score++;
            bestScore = score > bestScore ? score : bestScore;
        }

        public int GetScore()
        {
            return score;
        }

        public int GetBestScore()
        {
            return bestScore;
        }

        public void ResetScore()
        {
            score = 0;
        }
    } 
}
