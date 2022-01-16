using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.Architecture
{
    public class GameController : MonoBehaviour
    {
        // STATES
        private MenuState menuState;

        private BaseState currentlyActiveState;

        private void Start()
        {
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
            menuState = new MenuState();
        }
    } 
}
