using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodTalk : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private string[] texts;
    [SerializeField] private string[] explainTexts;
    [SerializeField] private float autoTalkSpan;

    private char[] chars;
    private Coroutine coroutine;

    void Start()
    {
        coroutine = StartCoroutine(ExplainTalkCoroutine());
    }

    IEnumerator ExplainTalkCoroutine()
    {
        for(int i = 0; i < explainTexts.Length; i++)
        {
            chars = explainTexts[i].ToCharArray();
            for (int j = 0; j < chars.Length; j++)
            {
                text.text += chars[j];
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(5f);
            text.text = "";
        }
        
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
}
