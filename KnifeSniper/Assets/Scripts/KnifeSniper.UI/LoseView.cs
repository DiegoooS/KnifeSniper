using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KnifeSniper.UI
{
    public class LoseView : BaseView
    {
        [SerializeField]
        private Button replayButton;

        [SerializeField]
        private Button backToMenuButton;

        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private TextMeshProUGUI stageText;

        public Button ReplayButton => replayButton;

        public Button BackToMenuButton => backToMenuButton;

        public void SetText(int score, int stage)
        {
            scoreText.text = score.ToString();
            stageText.text = $"STAGE {stage}";
        }
    }
}