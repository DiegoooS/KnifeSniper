using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.Generation
{
    public class LevelGenerator : MonoBehaviour
    {
        [Header("Knifes")]
        [SerializeField]
        private Transform knifePos;

        [SerializeField]
        private Transform knifeRoot;

        [SerializeField]
        private BaseKnife knifePrefab;

        [Header("Shields")]
        [SerializeField]
        private Transform shieldPos;  

        [SerializeField]
        private BaseShield shieldPrefab;

        [SerializeField]
        private Transform shieldRoot;

        

        public BaseShield SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, shieldPos.position, shieldPos.rotation);

            shieldObj.transform.SetParent(shieldRoot);

            return shieldObj;
        }

        public BaseKnife SpawnKnife()
        {
            var knifeObj = Instantiate(knifePrefab, knifePos.position, knifePos.rotation);

            knifeObj.transform.SetParent(knifeRoot);

            return knifeObj;
        }
    } 
}
