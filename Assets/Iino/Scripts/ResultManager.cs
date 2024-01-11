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
            //�J�E���g�����Z�b�g
            HumanManager.HumanDeathCount = 0;

            SceneManager.LoadScene(nextSceneName);
        }
    }

    void LoadRank()
    {
        //�X�R�A���烉���N���擾
        peopleDeath = HumanManager.HumanDeathCount;
        rank = RankManager.instance.GetRank(HumanManager.HumanDeathCount);
        UpdateResultText(rank);
    }

    void UpdateResultText(Rank rank)
    {
        //�\�L�̍X�V

        peopleHelpedNumText.text = "���񂾐l�F" + peopleDeath.ToString() + "�l";
        angelRank.text = rank.rank.ToString();
        godsComment.text = rank.comment.ToString();
    }
}
