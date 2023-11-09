using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TitleManager : MonoBehaviour
{

    [SerializeField]
    private Canvas titleCanvas;

    [SerializeField]
    private bool isPlayedTimeline;

    [SerializeField]
    private GameObject BlendCamera;


    void Update()
    {
        //InputSystemを使う場合はキー取得を切り替えること
        if(Input.anyKeyDown == true && !isPlayedTimeline)
        {
            BlendCamera.SetActive(true);
            isPlayedTimeline = true;
            titleCanvas.enabled = false;
        }
    }
}
