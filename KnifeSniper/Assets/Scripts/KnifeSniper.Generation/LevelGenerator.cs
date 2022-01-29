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
        private BaseShield[] simpleShields;

        [SerializeField]
        private BaseShield[] bossShields;

        [SerializeField]
        private Transform shieldRoot;

        
        public BaseShield SpawnShield(int currentStage)
        {
            BaseShield shieldToSpawn = default;

            if (currentStage < 5)
            {
                var randomIndexSimple = Random.Range(0, simpleShields.Length );
                shieldToSpawn = simpleShields[randomIndexSimple];
            }
            else
            {
                var randomIndexBoss = Random.Range(0, bossShields.Length );
                shieldToSpawn = bossShields[randomIndexBoss];
            }

            Debug.Log(currentStage);

            shieldToSpawn = Instantiate(shieldToSpawn, shieldPos.position, shieldPos.rotation);

            shieldToSpawn.transform.SetParent(shieldRoot);

            return shieldToSpawn;
        }

        public BaseKnife SpawnKnife()
        {
            var knifeObj = Instantiate(knifePrefab, knifePos.position, knifePos.rotation);

            knifeObj.transform.SetParent(knifeRoot);

            return knifeObj;
        }

        public void DespawnKnife()
        {
            if (knifeRoot.transform.GetChild(1) != null)
                Destroy(knifeRoot.transform.GetChild(1).gameObject);
        }
    } 
}
