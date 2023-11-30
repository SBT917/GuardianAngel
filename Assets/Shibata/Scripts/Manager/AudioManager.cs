using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AudioData
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)] public float volume = 1;
}

public class AudioManager : Singleton<AudioManager> //シングルトン継承
{
    [SerializeField] private AudioSource bgmSource; //AudioSource
    [SerializeField] private AudioSource seSource; //AudioSource

    [SerializeField] private List<AudioData> bgmDatas; //BGMのデータリスト
    [SerializeField] private List<AudioData> seDatas; //SEのデータリスト

    protected override void Awake()
    {
        DontDestroyOnLoad(this);
        base.Awake();
    }

    //指定した名前のBGMを再生
    public void PlayBGM(string name)
    {
        if (bgmSource == null) return;
        AudioData data = bgmDatas.Find(bgm => bgm.name == name);
        bgmSource.clip = data.clip;
        bgmSource.volume = data.volume;
        bgmSource.Play();
    }

    //指定した名前のSEを再生
    public void PlaySE(string name)
    {
        if (seSource == null) return;
        AudioData data = seDatas.Find(se => se.name == name);
        seSource.volume = data.volume;
        seSource.PlayOneShot(data.clip);
    }

    //BGMを停止させる
    public void StopBGM(bool fade, float seconds)
    {
        if (bgmSource == null) return;

        if (fade)
        {
            StartCoroutine(VolumeFadeOut(bgmSource, seconds));
            return;
        }

        bgmSource.Stop();
    }

    //AudioSourceの音量をフェードアウトさせる関数
    private IEnumerator VolumeFadeOut(AudioSource source, float seconds)
    {
        while (source.volume > 0)
        {
            source.volume -= (1.0f / 10.0f) / seconds;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        bgmSource.Stop();
    }
}