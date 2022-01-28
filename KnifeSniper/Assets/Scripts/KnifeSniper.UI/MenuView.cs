using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KnifeSniper.UI
{
    public class MenuView : BaseView
    {
        [SerializeField]
        private Button playButton;

        [SerializeField]
        private TextMeshProUGUI bestStageText;

        [SerializeField]
        private TextMeshProUGUI bestScoreText;
    
        public Button PlayButton => playButton;

        public void SetMenuUI(int bestStage, int bestScore)
        {
            bestStageText.text = $"STAGE {bestStage}";
            bestScoreText.text = $"SCORE {bestScore}";
        }
    }
}
