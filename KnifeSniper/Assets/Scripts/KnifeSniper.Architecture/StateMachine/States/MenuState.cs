using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using UnityEngine.Events;
using KnifeSniper.AdditionalSystems;
using KnifeSniper.Data;

namespace KnifeSniper.Architecture
{
    public class MenuState : BaseState
    {
        private MenuView menuView;
        private ScoreSystem scoreSystem;
        private LevelSystem levelSystem;
        private SaveSystem saveSystem;

        private UnityAction transitionToGameState;

        public MenuState(SaveSystem saveSystem, ScoreSystem scoreSystem, LevelSystem levelSystem, UnityAction transitionToGameState, MenuView menuView)
        {
            this.saveSystem = saveSystem;
            this.scoreSystem = scoreSystem;
            this.levelSystem = levelSystem;
            this.menuView = menuView;
            this.transitionToGameState = transitionToGameState;
        }

        public override void InitState()
        {
            Debug.Log("INIT MENU");

            menuView.PlayButton.onClick.AddListener(transitionToGameState);
            menuView.SetMenuUI(saveSystem.Data.stage, saveSystem.Data.score);

            if (menuView != null)
                menuView.ShowView();
        }

        public override void UpdateState()
        {
            
        }

        public override void DestroyState()
        {
            if (menuView != null)
                menuView.HideView();

            menuView.PlayButton.onClick.RemoveAllListeners();
        }
    }
}
