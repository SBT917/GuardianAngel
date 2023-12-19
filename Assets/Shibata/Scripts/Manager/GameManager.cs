using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    void Start()
    {
        TimeManager.instance.IsCounting = true;
        TimeManager.instance.onTimeCountZero += () =>
        {
            StartCoroutine(TransitionResult());
        };
    }

    private IEnumerator TransitionResult()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ResultScene");
    }

}
