using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.Generation;
using UnityEngine.Events;

namespace KnifeSniper.CoreGameplay
{
    public class ShieldMovementController
    {
        private BaseShield currentlyActiveShield;

        public void InitializeShield(BaseShield newShield, UnityAction onShieldHitCallback, UnityAction onWinCallback)
        {
            if (currentlyActiveShield != null)
            {
                currentlyActiveShield.Dispose();
            }

            currentlyActiveShield = newShield;
            currentlyActiveShield.Initialize(onShieldHitCallback, onWinCallback);
        }

        public void UpdateController()
        {
            if(currentlyActiveShield != null)
                currentlyActiveShield.Rotate();
        }
    } 
}
