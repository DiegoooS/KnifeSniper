using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.Generation
{
    public class TestKnife : BaseKnife
    {
        private Rigidbody2D RigidBody => rigidBody;

        public override void ThrowKnife()
        {
            rigidBody.AddForce(Vector2.up * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    } 
}
