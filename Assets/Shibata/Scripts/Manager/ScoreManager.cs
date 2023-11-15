using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int Score { get; private set; } //スコア

    public Action<int> onScoreChange;

    //スコアの増加
    public void AddScore(int score)
    {
        Score += score;
        onScoreChange?.Invoke(Score);
    }

    //スコアの減少
    public void RemoveScore(int score)
    {
        Score -= score;
        onScoreChange?.Invoke(Score);
    }
}
