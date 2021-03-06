using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using UnityEngine.Events;
using KnifeSniper.Input;
using KnifeSniper.Generation;
using KnifeSniper.CoreGameplay;
using KnifeSniper.AdditionalSystems;
using KnifeSniper.Data;

namespace KnifeSniper.Architecture
{
    public class GameController : MonoBehaviour
    {
        // VIEWS
        [SerializeField]
        private MenuView menuView;
        [SerializeField]
        private GameView gameView;
        [SerializeField]
        private LoseView loseView;

        // STATES 
        private MenuState menuState;
        private GameState gameState;

        private BaseState currentlyActiveState;

        private InputSystem inputSystem;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;
        private ScoreSystem scoreSystem;
        private LevelSystem levelSystem;
        private SaveSystem saveSystem;

        [SerializeField]
        private LevelGenerator levelGenerator;

        private UnityAction transitionToGameState;
        private UnityAction transitionToMenuState;

        private void Start()
        {
            inputSystem = new InputSystem();

            CreateSaveSystem();
            CreateTransitions();
            CreateShieldMovement();
            CreateKnifeThrower();
            CreateAdditionalSystems();
            CreateStates();

            saveSystem.LoadGame();
            ChangeState(menuState);
        }

        private void Update()
        {
            currentlyActiveState?.UpdateState();
        }

        private void OnDestroy()
        {
            
        }

        private void ChangeState(BaseState newState)
        {
            currentlyActiveState?.DestroyState();
            currentlyActiveState = newState;
            currentlyActiveState.InitState();
        }

        private void CreateStates()
        {
            menuState = new MenuState(saveSystem, scoreSystem, levelSystem, transitionToGameState, menuView);
            gameState = new GameState(saveSystem, transitionToMenuState, levelSystem, scoreSystem, knifeThrower, shieldMovementController, levelGenerator, inputSystem, gameView, loseView);
        }

        private void CreateTransitions()
        {
            transitionToGameState = () => ChangeState(gameState);
            transitionToMenuState = () => ChangeState(menuState);
        }

        private void CreateShieldMovement()
        {
            shieldMovementController = new ShieldMovementController();
        }

        private void CreateKnifeThrower()
        {
            knifeThrower = new KnifeThrower();
        }

        private void CreateAdditionalSystems()
        {
            scoreSystem = new ScoreSystem();
            levelSystem = new LevelSystem();
        }

        private void CreateSaveSystem()
        {
            saveSystem = new SaveSystem();
        }
    } 
}
