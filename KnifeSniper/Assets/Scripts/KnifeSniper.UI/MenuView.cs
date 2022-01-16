using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KnifeSniper.UI
{
    public class MenuView : BaseView
    {
        [SerializeField]
        private Button playButton;
    
        public Button PlayButton => playButton;
    }
}
