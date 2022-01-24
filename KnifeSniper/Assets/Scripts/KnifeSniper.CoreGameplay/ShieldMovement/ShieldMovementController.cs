using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeSniper.Generation;

namespace KnifeSniper.CoreGameplay
{
    public class ShieldMovementController
    {
        private BaseShield currentlyActiveShield;

        public void InitializeShield(BaseShield newShield)
        {
            // !!! HEY YOU - Destroy old shield

            currentlyActiveShield = newShield;
            currentlyActiveShield.Initialize();
        }

        public void UpdateController()
        {
            if(currentlyActiveShield != null)
                currentlyActiveShield.Rotate();
        }
    } 
}
