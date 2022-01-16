using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KnifeSniper.Input
{
    public class InputSystem
    {
        private UnityAction onClick;

        public void AddListener(UnityAction callback)
        {
            onClick += callback;
        }

        public void RemoveAllListeners()
        {
            onClick = null;
        }

        public void UpdateSystem()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space)
                || UnityEngine.Input.GetMouseButtonDown(0))
            {
                onClick.Invoke();
            }
        }
    } 
}
