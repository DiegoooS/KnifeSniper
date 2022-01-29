using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using KnifeSniper.Input;
using KnifeSniper.Generation;
using KnifeSniper.CoreGameplay;
using KnifeSniper.AdditionalSystems;
using UnityEngine.Events;
using DG.Tweening;

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
            UnityAction onShieldHit = gameView.DecreaseAmmo;
            onShieldHit += CreateNewKnife;
            onShieldHit += scoreSystem.AddScore;
            onShieldHit += () => gameView.SetScoreText(scoreSystem.GetScore());

            levelSystem.NextLevel();

            newShield = levelGenerator.SpawnShield(levelSystem.GetCurrentStage());
            shieldMovementController.InitializeShield(newShield, onShieldHit, CreateNewShield);
    
            gameView.SetCurrentLevelUI(levelSystem.GetCurrentLevel(), levelSystem.GetCurrentStage());
            gameView.SpawnAmmo(newShield.KnifesToWin);
        }

        private void CreateNewKnife()
        {
            var newKnife = levelGenerator.SpawnKnife();

            newKnife.Initialize(() =>  GameOver(newKnife));

            knifeThrower.SetKnife(newKnife); 
        }

        private void GameOver(BaseKnife lastKnife)
        {
            lastKnife.RigidBody.gravityScale = 5f;
            lastKnife.RigidBody.AddTorque(360f, ForceMode2D.Force);
            lastKnife.GetComponent<PolygonCollider2D>().enabled = false;

            var loseSequence = DOTween.Sequence();
            loseSequence
                .SetDelay(0.7f)
                .OnComplete(() =>
                {
                    loseView.ShowView();
                    newShield.Dispose();
                    gameView.HideView();
                });

            loseView.SetText(scoreSystem.GetScore(), levelSystem.GetCurrentLevel());
            
        }
    } 
}
