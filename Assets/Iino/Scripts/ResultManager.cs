using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Text peopleHelpedNumText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text angelRank;
    [SerializeField]
    private Text godsComment;


    [SerializeField]
    private int peopleHelped;
    private int score;

    [SerializeField]
    private int debugScore;

    [SerializeField]
    private string nextSceneName;

    private Rank rank;

    private InputAction _pressAnyKeyAction =
        new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>", interactions: "Press");

    private void OnEnable() => _pressAnyKeyAction.Enable();
    private void OnDisable() => _pressAnyKeyAction.Disable();

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.instance.AddScore(debugScore);
        LoadRank();
    }

    // Update is called once per frame
    void Update()
    {
        if (_pressAnyKeyAction.triggered)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void LoadRank()
    {
        //スコアからランクを取得
        score = ScoreManager.instance.Score;
        rank = RankManager.instance.GetRank(score);
        UpdateResultText(rank);
    }

    void UpdateResultText(Rank rank)
    {
        //表記の更新

        peopleHelpedNumText.text = "助けた人：" + peopleHelped.ToString() + "人";
        scoreText.text = "最終スコア：" + score.ToString("N0");
        angelRank.text = rank.rank.ToString();
        godsComment.text = rank.comment.ToString();
    }
}
