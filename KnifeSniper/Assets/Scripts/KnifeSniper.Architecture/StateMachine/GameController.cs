using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.UI;
using UnityEngine.Events;
using KnifeSniper.Input;
using KnifeSniper.Generation;

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

        [SerializeField]
        private LevelGenerator levelGenerator;

        private UnityAction transitionToGameState;

        private void Start()
        {
            inputSystem = new InputSystem();

            CreateTransitions();
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
            menuState = new MenuState(transitionToGameState, menuView);
            gameState = new GameState(levelGenerator, inputSystem, gameView);
        }

        private void CreateTransitions()
        {
            transitionToGameState = () => ChangeState(gameState);
        }
    } 
}
