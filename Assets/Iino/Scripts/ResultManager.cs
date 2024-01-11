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
    private Text angelRank;
    [SerializeField]
    private Text godsComment;


    [SerializeField]
    private int peopleDeath;

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
        LoadRank();
    }

    // Update is called once per frame
    void Update()
    {
        if (_pressAnyKeyAction.triggered)
        {
            //カウントをリセット
            HumanManager.HumanDeathCount = 0;

            SceneManager.LoadScene(nextSceneName);
        }
    }

    void LoadRank()
    {
        //スコアからランクを取得
        peopleDeath = HumanManager.HumanDeathCount;
        rank = RankManager.instance.GetRank(HumanManager.HumanDeathCount);
        UpdateResultText(rank);
    }

    void UpdateResultText(Rank rank)
    {
        //表記の更新

        peopleHelpedNumText.text = "死んだ人：" + peopleDeath.ToString() + "人";
        angelRank.text = rank.rank.ToString();
        godsComment.text = rank.comment.ToString();
    }
}
