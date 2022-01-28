using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using KnifeSniper.Input;
using KnifeSniper.Generation;
using KnifeSniper.CoreGameplay;
using KnifeSniper.AdditionalSystems;

namespace KnifeSniper.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;
        private ScoreSystem scoreSystem;
        private LevelSystem levelSystem;

        public GameState(
            LevelSystem levelSystem,
            ScoreSystem scoreSystem,
            KnifeThrower knifeThrower, 
            ShieldMovementController shieldMovementController, 
            LevelGenerator levelGenerator,
            InputSystem inputSystem, 
            GameView gameView
            )
        {
            this.levelSystem = levelSystem;
            this.scoreSystem = scoreSystem;
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
            gameView.SetScoreText(scoreSystem.GetScore());
            gameView.SetCurrentLevelUI(levelSystem.GetCurrentLevel(), levelSystem.GetCurrentStage());
            inputSystem.AddListener(knifeThrower.Throw);
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
            levelSystem.ResetLevelValues();
        }

        private void CreateNewShield()
        {
            var startShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(startShield, OnShieldHit, CreateNewShield);

            levelSystem.NextLevel();
            gameView.SetCurrentLevelUI(levelSystem.GetCurrentLevel(), levelSystem.GetCurrentStage());
        }

        private void OnShieldHit()
        {
            CreateNewKnife();
            scoreSystem.AddScore();
            gameView.SetScoreText(scoreSystem.GetScore());
        }

        private void CreateNewKnife()
        {
            var newKnife = levelGenerator.SpawnKnife();
            knifeThrower.SetKnife(newKnife);
        }
    } 
}
