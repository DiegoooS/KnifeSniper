using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KnifeSniper.UI
{
    public class GameView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private TextMeshProUGUI levelText;

        [SerializeField]
        private Image stageImage1;

        [SerializeField]
        private Image stageImage2;

        [SerializeField]
        private Image stageImage3;

        [SerializeField]
        private Image stageImage4;

        [SerializeField]
        private Image stageImageBoss;

        [SerializeField]
        private KnifeAmmoElement knifeAmmoElementPrefab;

        [SerializeField]
        private RectTransform knifeElementContent;

        private List<KnifeAmmoElement> spawnedElements = new List<KnifeAmmoElement>();

        private int knifeToDelete;

        public void SetScoreText(int currentScore)
        {
            scoreText.text = currentScore.ToString();
        }

        public void SetCurrentLevelUI(int currentLevel, int currentStage)
        {
            levelText.text = currentStage < 5 ? $"STAGE {currentLevel}" : "BOSS FIGHT";
            levelText.color = currentStage < 5 ? Color.white : Color.red;

            stageImage1.color = Color.yellow;
            stageImage2.color = currentStage >= 2 ? Color.yellow : Color.white;
            stageImage3.color = currentStage >= 3 ? Color.yellow : Color.white;
            stageImage4.color = currentStage >= 4 ? Color.yellow : Color.white;
            stageImageBoss.color = currentStage == 5 ? Color.yellow : Color.white;
        }

        public void SpawnAmmo(int amount)
        {
            DespawnKnives();

            for (int i = 0; i < amount; i++)
            {
                var newKnife = Instantiate(knifeAmmoElementPrefab, knifeElementContent);
                spawnedElements.Add(newKnife);
                newKnife.MarkAsUnlocked();
            }

            knifeToDelete = -1;
        }

        private void DespawnKnives()
        {
            for (int i = spawnedElements.Count - 1; i >= 0; i--)
            {
                Destroy(spawnedElements[i].gameObject);
            }

            spawnedElements.Clear();
        }

        public void DecreaseAmmo()
        {
            knifeToDelete++;
            spawnedElements[knifeToDelete].MarkAsLocked();
        }
    } 
}
