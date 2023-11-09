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
        //InputSystem‚ğg‚¤ê‡‚ÍƒL[æ“¾‚ğØ‚è‘Ö‚¦‚é‚±‚Æ
        if(Input.anyKeyDown == true && !isPlayedTimeline)
        {
            BlendCamera.SetActive(true);
            isPlayedTimeline = true;
            titleCanvas.enabled = false;
        }
    }
}
