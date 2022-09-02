using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRecordManager
{
    public void RecordMatch(string[] playersID, int[] playersScore, string[] playersColor)
    {
        AllMatchData allMatchData = LoadMatchRecord();

        int index = allMatchData.MatchRecord.Length >= 19 ? 19 : allMatchData.MatchRecord.Length + 1;

        DataMatchRecord[] dataMatchRecords = new DataMatchRecord[index];

        dataMatchRecords[0] = new DataMatchRecord(playersID, playersScore, playersColor);

        for (int i = 0; i < allMatchData.MatchRecord.Length; i++)
        {
            dataMatchRecords[i + 1] = allMatchData.MatchRecord[i];
        }

        PlayerPrefs.SetString("MatchData", JsonUtility.ToJson(new AllMatchData(dataMatchRecords)));

    }

    public AllMatchData LoadMatchRecord()
    {
        string json = PlayerPrefs.GetString("MatchData");

        if (string.IsNullOrWhiteSpace(json))
        {
            return new AllMatchData(new DataMatchRecord[0]);
        }

        return JsonUtility.FromJson<AllMatchData>(json);
    }
}

[System.Serializable]
public class AllMatchData
{
    public DataMatchRecord[] MatchRecord;

    public AllMatchData(DataMatchRecord[] data)
    {
        MatchRecord = data;
    }
}

[System.Serializable]
public class DataMatchRecord
{
    public string[] playersID;
    public int[] playersScore;
    public string[] playersColor;

    public DataMatchRecord(string[] playersID, int[] playersScore, string[] playersColor)
    {
        this.playersID = playersID;
        this.playersScore = playersScore;
        this.playersColor = playersColor;
    }

}
