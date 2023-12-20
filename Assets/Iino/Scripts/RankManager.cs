using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Rank
{
    public string rank;
    public int maxScore;
    public string comment;
}

[Serializable]
public class RankList
{
    public List<Rank> ranks;
}

public class RankManager : MonoBehaviour
{
    public RankList RankList;

    public static RankManager instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        LoadRanks();
    }


    void LoadRanks()
    {
        TextAsset ranksJson = Resources.Load<TextAsset>("Ranks");
        RankList = JsonUtility.FromJson<RankList>(ranksJson.text);
    }

    public Rank GetRank(int score)
    {
        foreach (var rank in RankList.ranks)
        {
            if(score <= rank.maxScore)
            {
                return rank;
            }
        }
        return null;
    }
}
