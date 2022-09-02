using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHistory
{
    public void PlayerRecord(string[] id, string winnerId)
    {
        PlayerData[] players = LoadData();
        bool isPlayerFound = false;

        foreach (string player in id)
        {
            isPlayerFound = false;
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].id == player)
                {
                    players[i].totalMatch += 1;
                    isPlayerFound = true;
                    break;
                }
            }
            if(!isPlayerFound)
            {
                PlayerData[] temp = players;
                players = new PlayerData[temp.Length + 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    players[i] = temp[i];
                }
                players[temp.Length].id = player;
                players[temp.Length].totalMatch += 1;
            }
        }

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].id == winnerId)
            {
                players[i].winCount += 1;
                break;
            }
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
    public int totalMatch;

    public int LevelCounter(int baseEXPLevel)
    {
        int level = EXPCounter();
        Debug.Log(level);
        return Mathf.FloorToInt(level / baseEXPLevel) + 1;
    }
    public int EXPCounter()
    {
        int match = totalMatch - winCount;
        if (match <= 0)
        {
            match = 0;
        }
        
        int exp = winCount * 100;
        exp += match * 50;
        return exp;
    }
}

[System.Serializable]
public struct ArrayPlayer
{
    public PlayerData[] arrayPlayer;
}