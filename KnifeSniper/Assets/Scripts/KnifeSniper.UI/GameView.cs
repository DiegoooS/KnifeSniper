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

        public void SetCurrentLevelUI(int currentLevel)
        {
            levelText.text = currentLevel.ToString();

            stageImage1.color = new Color(200f, 167f, 82f);

            // Do Wyjebania :(
            stageImage2.color = currentLevel / 2 == 1 ? new Color(200f, 167f, 82f) : Color.white;
            stageImage3.color = currentLevel / 3 == 1 ? new Color(200f, 167f, 82f) : Color.white;
            stageImage4.color = currentLevel / 4 == 1 ? new Color(200f, 167f, 82f) : Color.white;
            stageImageBoss.color = currentLevel / 5 == 1 ? new Color(200f, 167f, 82f) : Color.white;
        }
    } 
}
