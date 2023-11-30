using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TestManager : MonoBehaviour
{
    public static TestManager Instance;

    [SerializeField]
    private GameObject blackPanel;
    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        blackPanel.SetActive(true);
        Invoke("LoadResultScene", 3f);
    }

    private void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
