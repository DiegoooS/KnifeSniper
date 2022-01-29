using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KnifeSniper.UI
{
    public class KnifeAmmoElement : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        public void MarkAsUnlocked()
        {
            image.color = Color.white;
        }
        
        public void MarkAsLocked()
        {
            image.color = Color.black;
        }
    } 
}
