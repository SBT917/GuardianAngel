using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialTalkText : MonoBehaviour, Controls.ITutorialActions
{
    [SerializeField] private Text text;
    [SerializeField] private string[] texts;

    private char[] chars;
    private int currentIndex;
    private Controls controls;
    private Coroutine coroutine;

    void OnEnable()
    {
        controls = new Controls();
        controls.Tutorial.SetCallbacks(this);
        controls.Tutorial.Enable();
    }

    void OnDisable()
    {
        controls.Tutorial.Disable();    
    }

    void Start()
    {
        currentIndex = 0;
        chars = texts[currentIndex].ToCharArray();
        coroutine = StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        for(int i = 0; i < chars.Length; i++)
        {
            text.text += chars[i];
            yield return new WaitForSeconds(0.1f);
        }

        coroutine = null;
    }

    public void OnText(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
            text.text = texts[currentIndex];
            return;
        }

        if (currentIndex >= texts.Length - 1)
        {
            SceneManager.LoadScene("Map");
            return;
        }

        ++currentIndex;
        chars = texts[currentIndex].ToCharArray();
        text.text = "";
        coroutine = StartCoroutine(TextCoroutine());
    }
}
