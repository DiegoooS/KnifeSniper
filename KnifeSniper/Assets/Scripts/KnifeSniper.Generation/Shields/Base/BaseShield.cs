using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField]
        protected ShieldMovementStep[] shieldMovementStep;

        public abstract void Rotate();
        public abstract void Initialize();
    } 
}
