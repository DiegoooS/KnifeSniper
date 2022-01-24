using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using KnifeSniper.Input;
using KnifeSniper.Generation;
using KnifeSniper.CoreGameplay;

namespace KnifeSniper.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;

        public GameState(ShieldMovementController shieldMovementController, LevelGenerator levelGenerator, InputSystem inputSystem, GameView gameView)
        {
            this.inputSystem = inputSystem;
            this.gameView = gameView;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
        }

        public override void InitState()
        {
            Debug.Log("INIT GAME");

            if (gameView != null)
                gameView.ShowView();

            var startShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(startShield);

            levelGenerator.SpawnKnife();
            inputSystem.AddListener(PrintDebug);
        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
            shieldMovementController.UpdateController();
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
