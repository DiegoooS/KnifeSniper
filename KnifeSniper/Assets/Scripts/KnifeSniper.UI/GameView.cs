using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KnifeSniper.UI
{
    public class GameView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        public TextMeshProUGUI ScoreText => scoreText;
    } 
}
