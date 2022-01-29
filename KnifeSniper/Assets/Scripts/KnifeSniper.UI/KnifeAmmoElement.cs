using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
            image.DOColor(Color.black, 0.3f);
        }
    } 
}
