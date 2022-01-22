using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using KnifeSniper.Input;
using KnifeSniper.Generation;

namespace KnifeSniper.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;

        public GameState(LevelGenerator levelGenerator, InputSystem inputSystem, GameView gameView)
        {
            this.inputSystem = inputSystem;
            this.gameView = gameView;
            this.levelGenerator = levelGenerator;
        }

        public override void InitState()
        {
            Debug.Log("INIT GAME");

            if (gameView != null)
                gameView.ShowView();

            levelGenerator.SpawnShield();
            levelGenerator.SpawnKnife();
            inputSystem.AddListener(PrintDebug);
        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
        }

        public override void DestroyState()
        {
            if (gameView != null)
                gameView.HideView();

            inputSystem.RemoveAllListeners();
        }

        private void PrintDebug()
        {
            Debug.Log("Pressed");
        }
    } 
}