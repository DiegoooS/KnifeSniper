using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KnifeSniper.Data
{
    [Serializable]
    public class PlayerData
    {
        public int stage;
        public int score;

        public PlayerData(int stage, int score)
        {
            this.stage = stage;
            this.score = score;
        }
    }

    public class SaveSystem
    {
        private PlayerData data;
        public PlayerData Data => data;

        public void LoadGame()
        {
            if (PlayerPrefs.HasKey("PLAYER_SAVE"))
            {
                Debug.Log(PlayerPrefs.GetString("PLAYER_SAVE"));
                data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PLAYER_SAVE"));
            }
            else
            {
                data = new PlayerData(0, 0);
                SaveGame(data.stage, data.score);
            }
        }

        public void SaveGame(int stage, int score)
        {
            Debug.Log("saving");

            data = new PlayerData(stage, score);
            PlayerPrefs.SetString("PLAYER_SAVE", JsonUtility.ToJson(data));
        }
    } 
}
