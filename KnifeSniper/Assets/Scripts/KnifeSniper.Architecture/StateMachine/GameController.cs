using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using UnityEngine.Events;
using KnifeSniper.Input;
using KnifeSniper.Generation;
using KnifeSniper.CoreGameplay;
using KnifeSniper.AdditionalSystems;

namespace KnifeSniper.Architecture
{
    public class GameController : MonoBehaviour
    {
        // VIEWS
        [SerializeField]
        private MenuView menuView;
        [SerializeField]
        private GameView gameView;

        // STATES
        private MenuState menuState;
        private GameState gameState;

        private BaseState currentlyActiveState;

        private InputSystem inputSystem;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;
        private ScoreSystem scoreSystem;
        private LevelSystem levelSystem;

        [SerializeField]
        private LevelGenerator levelGenerator;

        private UnityAction transitionToGameState;

        private void Start()
        {
            inputSystem = new InputSystem();
    
            CreateTransitions();
            CreateShieldMovement();
            CreateKnifeThrower();
            CreateAdditionalSystems();
            CreateStates();

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
            menuState = new MenuState(scoreSystem, levelSystem, transitionToGameState, menuView);
            gameState = new GameState(levelSystem, scoreSystem, knifeThrower, shieldMovementController, levelGenerator, inputSystem, gameView);
        }

        private void CreateTransitions()
        {
            transitionToGameState = () => ChangeState(gameState);
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
    } 
}
