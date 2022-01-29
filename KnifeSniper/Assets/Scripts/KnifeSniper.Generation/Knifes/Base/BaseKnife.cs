using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KnifeSniper.Generation
{
    public abstract class BaseKnife : MonoBehaviour
    {
        [SerializeField]
        protected Rigidbody2D rigidBody;

        private UnityAction onKnifeHitCallback;

        public Rigidbody2D RigidBody => rigidBody;

        [SerializeField]
        protected float speed;

        public virtual void Initialize(UnityAction onKnifeHitCallback)
        {
            this.onKnifeHitCallback = onKnifeHitCallback;
        }

        public abstract void ThrowKnife();

        private void OnCollisionEnter2D(Collision2D collision)
        {

            Destroy(this.gameObject);
            onKnifeHitCallback.Invoke();
        }
    } 
}
