using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GodTalk : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private string[] texts;
    [SerializeField] private string[] explainTexts;
    [SerializeField] private string[] explainTextsKeyboard;
    [SerializeField] private float autoTalkSpan;

    private bool isExplained = false;
    private char[] chars;
    private Coroutine coroutine;

    void Start()
    {
        if(Gamepad.current!=null) coroutine = StartCoroutine(ExplainTalkCoroutine(explainTexts));
        else coroutine = StartCoroutine(ExplainTalkCoroutine(explainTextsKeyboard));
    }

    IEnumerator ExplainTalkCoroutine(string[] explainText)
    {
        for(int i = 0; i < explainText.Length; i++)
        {
            chars = explainText[i].ToCharArray();
            for (int j = 0; j < chars.Length; j++)
            {
                text.text += chars[j];
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(5f);
            text.text = "";
        }

        isExplained = true;
        coroutine = StartCoroutine(AutoTalkCoroutine());
    }

    IEnumerator AutoTalkCoroutine()
    {
        while(true)
        {
            chars = texts[Random.Range(0, texts.Length)].ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                text.text += chars[i];
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(autoTalkSpan);
            text.text = "";
        }  
    }

    void EventTalk(string talkString)
    {
        if (!isExplained) return;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }

        text.text = "";
        coroutine = StartCoroutine(EventTalkCoroutine(talkString));
    }

    IEnumerator EventTalkCoroutine(string talkString)
    {
        chars = talkString.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            text.text += chars[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(autoTalkSpan);

        text.text = "";
        coroutine = StartCoroutine(AutoTalkCoroutine());
    }
}
