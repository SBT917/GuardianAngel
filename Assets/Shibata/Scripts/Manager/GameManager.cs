using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool IsPaused {  get; private set; }

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

    public void PauseGame()
    {
        Time.timeScale = 0;
        IsPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        IsPaused = false;
    }

}
