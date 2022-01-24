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
        private KnifeThrower knifeThrower;

        public GameState(KnifeThrower knifeThrower, 
            ShieldMovementController shieldMovementController, 
            LevelGenerator levelGenerator,
            InputSystem inputSystem, 
            GameView gameView
            )
        {
            this.inputSystem = inputSystem;
            this.gameView = gameView;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
            this.knifeThrower = knifeThrower;
        }

        public override void InitState()
        {
            Debug.Log("INIT GAME");

            if (gameView != null)
                gameView.ShowView();

            CreateNewShield();
            CreateNewKnife();
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

        private void CreateNewShield()
        {
            var startShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(startShield);
        }

        private void CreateNewKnife()
        {
            var newKnife = levelGenerator.SpawnKnife();
            inputSystem.AddListener(newKnife.ThrowKnife);
        }
    } 
}
