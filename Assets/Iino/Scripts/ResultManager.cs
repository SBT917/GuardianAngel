using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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

    private Rank rank;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.instance.AddScore(debugScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            LoadRank();
        }
    }

    void LoadRank()
    {
        //�X�R�A���烉���N���擾
        score = ScoreManager.instance.Score;
        rank = RankManager.instance.GetRank(score);
        UpdateResultText(rank);
    }

    void UpdateResultText(Rank rank)
    {
        //�\�L�̍X�V

        peopleHelpedNumText.text = "�������l�F" + peopleHelped.ToString() + "�l";
        scoreText.text = "�ŏI�X�R�A�F" + score.ToString("N0");
        angelRank.text = rank.rank.ToString();
        godsComment.text = rank.comment.ToString();
    }
}
