using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using KnifeSniper.Input;
using KnifeSniper.Generation;
using KnifeSniper.CoreGameplay;
using KnifeSniper.AdditionalSystems;
using UnityEngine.Events;

namespace KnifeSniper.Architecture
{
    public class GameState : BaseState
    {
        private UnityAction transitionToMenuState;
        private GameView gameView;
        private LoseView loseView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;
        private ScoreSystem scoreSystem;
        private LevelSystem levelSystem;

        private BaseShield newShield;

        public GameState(
            UnityAction transitionToMenuState,
            LevelSystem levelSystem,
            ScoreSystem scoreSystem,
            KnifeThrower knifeThrower, 
            ShieldMovementController shieldMovementController, 
            LevelGenerator levelGenerator,
            InputSystem inputSystem, 
            GameView gameView,
            LoseView loseView
            )
        {
            this.transitionToMenuState = transitionToMenuState;
            this.levelSystem = levelSystem;
            this.scoreSystem = scoreSystem;
            this.inputSystem = inputSystem;
            this.gameView = gameView;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
            this.knifeThrower = knifeThrower;
            this.loseView = loseView;
        }

        public override void InitState()
        {
            Debug.Log("INIT GAME"); 

            loseView.ReplayButton.onClick.AddListener(InitializeGame);
            loseView.BackToMenuButton.onClick.AddListener(transitionToMenuState);

            InitializeGame();
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

            if (loseView != null)
                loseView.HideView();

            if (newShield != null)
                newShield.Dispose();

            inputSystem.RemoveAllListeners();
            levelSystem.ResetLevelValues();
            loseView.ReplayButton.onClick.RemoveAllListeners();
            loseView.BackToMenuButton.onClick.RemoveAllListeners();
        }

        private void InitializeGame()
        {
            if (gameView != null)
                gameView.ShowView();

            if (loseView != null)
            {
                loseView.HideView();
            }

            levelSystem.ResetLevelValues();
            scoreSystem.ResetScore();
            CreateNewShield();
            CreateNewKnife();
            gameView.SetScoreText(scoreSystem.GetScore());
            gameView.SetCurrentLevelUI(levelSystem.GetCurrentLevel(), levelSystem.GetCurrentStage());
            inputSystem.AddListener(knifeThrower.Throw);
        }

        private void CreateNewShield()
        {
            newShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(newShield, OnShieldHit, CreateNewShield);

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

            newKnife.Initialize(GameOver);

            knifeThrower.SetKnife(newKnife);
        }

        private void GameOver()
        {
            newShield.Dispose();
            gameView.HideView();
            loseView.SetText(scoreSystem.GetScore(), levelSystem.GetCurrentLevel());
            loseView.ShowView();
        }
    } 
}
