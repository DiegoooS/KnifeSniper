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

        public GameState(
            ScoreSystem scoreSystem,
            KnifeThrower knifeThrower, 
            ShieldMovementController shieldMovementController, 
            LevelGenerator levelGenerator,
            InputSystem inputSystem, 
            GameView gameView
            )
        {
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
            SetScoreText();
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
        }

        private void CreateNewShield()
        {
            var startShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(startShield, OnShieldHit, CreateNewShield);
        }

        private void OnShieldHit()
        {
            CreateNewKnife();
            scoreSystem.AddScore();
            SetScoreText();
        }

        private void CreateNewKnife()
        {
            var newKnife = levelGenerator.SpawnKnife();
            knifeThrower.SetKnife(newKnife);
        }

        private void SetScoreText()
        {
            gameView.ScoreText.text = scoreSystem.GetScore().ToString();
        }
    } 
}
