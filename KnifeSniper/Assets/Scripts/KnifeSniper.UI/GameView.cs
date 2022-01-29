using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KnifeSniper.UI
{
    public class GameView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private TextMeshProUGUI levelText;

        [SerializeField]
        private Image stageImage1;

        [SerializeField]
        private Image stageImage2;

        [SerializeField]
        private Image stageImage3;

        [SerializeField]
        private Image stageImage4;

        [SerializeField]
        private Image stageImageBoss;

        public void SetScoreText(int currentScore)
        {
            scoreText.text = currentScore.ToString();
        }

        public void SetCurrentLevelUI(int currentLevel, int currentStage)
        {
            levelText.text = currentLevel.ToString();

            stageImage1.color = Color.yellow;
            stageImage2.color = currentStage >= 2 ? Color.yellow : Color.white;
            stageImage3.color = currentStage >= 3 ? Color.yellow : Color.white;
            stageImage4.color = currentStage >= 4 ? Color.yellow : Color.white;
            stageImageBoss.color = currentStage == 5 ? Color.yellow : Color.white;
        }
    } 
}
