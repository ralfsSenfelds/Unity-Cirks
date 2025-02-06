using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveLoadScript : MonoBehaviour
{
    public string saveFileName = "saveFile.json";

    [Serializable]
    public class GameData
    {
        public int characterIndex;
        public string playerName;
        // ...
    }

    private GameData gameData = new GameData();

    public void SaveGame(int character, string name)
    {
        gameData.characterIndex = character;
        gameData.playerName = name;

        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/" + saveFileName, json);
        Debug.Log("Game Saved to " + Application.persistentDataPath + "/" + saveFileName);
    }

    public void LoadGame()
    {
        string filepath = Application.persistentDataPath + "/" + saveFileName;

        if(File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            gameData = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Game loaded from " + filepath + "" + "\nCharacterIndex: " + gameData.characterIndex + "\nPlayer name: " + gameData.playerName);
        }
        else
        {
            Debug.LogError("Save file not found: " + filepath);
        }
    }
}
