using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.Generation
{
    public abstract class BaseKnife : MonoBehaviour
    {
        [SerializeField]
        protected Rigidbody2D rigidBody;

        [SerializeField]
        protected float speed;

        public abstract void ThrowKnife();
    } 
}
