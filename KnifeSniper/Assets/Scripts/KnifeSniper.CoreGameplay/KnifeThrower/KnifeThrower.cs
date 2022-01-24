using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KnifeSniper.Generation;

namespace KnifeSniper.CoreGameplay
{
    public class KnifeThrower
    {
        private BaseKnife knifeToThrow;

        public void SetKnife(BaseKnife newKnife)
        {
            knifeToThrow = newKnife;
        }

        public void Throw()
        {
            knifeToThrow?.ThrowKnife();
            knifeToThrow = null;
        }
    }

}