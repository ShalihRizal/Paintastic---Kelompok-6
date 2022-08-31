using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHistory
{
    public void OnPlayerWin(string id)
    {
        bool isWinnerFound = false;
        PlayerData[] players = LoadData();
        for (int i=0; i<players.Length; i++)
        {
            if(players[i].id == id)
            {
                players[i].winCount += 1;
                isWinnerFound = true;
            }
        }
        if (!isWinnerFound)
        {
            PlayerData[] temp = players;
            players = new PlayerData[temp.Length + 1];
            for (int i=0; i<temp.Length; i++)
            {
                players[i] = temp[i];
            }
            players[temp.Length].id = id;
            players[temp.Length].winCount += 1;
        }
        ArrayPlayer arrayPlayer = new ArrayPlayer();
        arrayPlayer.arrayPlayer = players;
        SaveData(arrayPlayer);
    }
    public PlayerData[] LoadData()
    {
        string json = PlayerPrefs.GetString("SaveData");
        
        ArrayPlayer arrayData;
        if (string.IsNullOrWhiteSpace(json))
        {
            arrayData = new ArrayPlayer();
            arrayData.arrayPlayer = new PlayerData[0];
        }
        else
        {
            arrayData = JsonUtility.FromJson<ArrayPlayer>(json);
            /*Debug.Log(arrayData.arrayPlayer[0].id);
            Debug.Log(arrayData.arrayPlayer[0].winCount);*/
        }
        return arrayData.arrayPlayer;
        

    }
    public void SaveData(ArrayPlayer data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", json);
        Debug.Log(json);
    }
    
    
}

[System.Serializable]
public struct PlayerData
{
    public string id;
    public int winCount;
}

[System.Serializable]
public struct ArrayPlayer
{
    public PlayerData[] arrayPlayer;
}