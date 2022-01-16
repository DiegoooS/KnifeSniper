using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using UnityEngine.Events;

namespace KnifeSniper.Architecture
{
    public class MenuState : BaseState
    {
        private MenuView menuView;

        private UnityAction transitionToGameState;

        public MenuState(UnityAction transitionToGameState, MenuView menuView)
        {
            this.menuView = menuView;
            this.transitionToGameState = transitionToGameState;
        }

        public override void InitState()
        {
            Debug.Log("INIT MENU");

            menuView.PlayButton.onClick.AddListener(transitionToGameState);

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
