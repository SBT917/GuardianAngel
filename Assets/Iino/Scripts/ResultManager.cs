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


    //�f�o�b�O�p�@�X�R�A�𒼐ڑł�����
    [SerializeField]
    private int peopleHelped;
    [SerializeField]
    private int score;

    private Rank rank;
    // Start is called before the first frame update
    void Start()
    {

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
        rank = RankManager.instance.GetRank(score);
        UpdateResultText(rank);
    }

    void UpdateResultText(Rank rank)
    {
        if (rank == null)
        {
            Debug.LogError("Rank object is null.");
            return;
        }

        peopleHelpedNumText.text = "�������l�F" + peopleHelped.ToString() + "�l";
        scoreText.text = "�ŏI�X�R�A�F" + score.ToString();
        angelRank.text = rank.rank.ToString();
        godsComment.text = rank.comment.ToString();
    }
}
