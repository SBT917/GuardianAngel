using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int Score { get; private set; } //�X�R�A

    public Action<int> onScoreChange;

    //�X�R�A�̑���
    public void AddScore(int score)
    {
        Score += score;
        onScoreChange?.Invoke(Score);
    }

    //�X�R�A�̌���
    public void RemoveScore(int score)
    {
        Score -= score;
        onScoreChange?.Invoke(Score);
    }
}
