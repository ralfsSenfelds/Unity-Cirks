using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;

public class PlayerScript : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int characterIndex;
    public GameObject spawnPoint;
    int[] otherPlayers;
    int index;

    private const string textFileName = "playerNames";

    void Start()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject mainCharacter = Instantiate(playerPrefabs[characterIndex], spawnPoint.transform.position, Quaternion.identity);
        mainCharacter.GetComponent<NameScript>().SetPlayerName(PlayerPrefs.GetString("PlayerName"));

        otherPlayers = new int[PlayerPrefs.GetInt("PlayerCount")];
        string[] nameArray = ReadLinesFromFile(textFileName);
        for(int i=0; i<otherPlayers.Length-1; i++)
        {
            spawnPoint.transform.position += new Vector3(0.2f, 0, 0.06f);
            index = Random.Range(0, playerPrefabs.Length-1);
            GameObject character = Instantiate(playerPrefabs[characterIndex], spawnPoint.transform.position, Quaternion.identity);
            character.GetComponent<NameScript>().SetPlayerName(nameArray[Random.Range(0, nameArray.Length-1)]);
        }

    }
    string[] ReadLinesFromFile(string fname)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fname);
        if(textAsset != null )
        {
            return textAsset.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        }
        else
        {
            Debug.LogError("File not found: " + fname); 
            return new string[0];
        }
    }
}
