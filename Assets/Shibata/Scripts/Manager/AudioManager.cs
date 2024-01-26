using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AudioData
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)] public float volume = 0.5f;
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager> //�V���O���g���p��
{
    private AudioSource audioSource; //AudioSource

    [SerializeField] private List<AudioData> bgmDatas; //BGM�̃f�[�^���X�g
    [SerializeField] private List<AudioData> seDatas; //SE�̃f�[�^���X�g

    protected override void Awake()
    {
        DontDestroyOnLoad(this);
        TryGetComponent(out audioSource);
        base.Awake();
    }

    //�w�肵�����O��BGM���Đ�
    public void PlayBGM(string name)
    {
        AudioData data = bgmDatas.Find(bgm => bgm.name == name);
        audioSource.clip = data.clip;
        audioSource.volume = data.volume;
        audioSource.Play();
    }

    public void PlaySE(string name)
    {
        AudioData data = seDatas.Find(bgm => bgm.name == name);
        audioSource.clip = data.clip;
        audioSource.volume = data.volume;
        audioSource.Play();
    }

    //�w�肵�����O��SE���Đ�
    public void PlaySE(string name, Vector3 position)
    {
        AudioData data = seDatas.Find(se => se.name == name);
        AudioSource.PlayClipAtPoint(data.clip, position, data.volume);
    }

    //BGM���~������
    public void StopBGM(bool fade, float seconds)
    {

        if (fade)
        {
            StartCoroutine(VolumeFadeOut(audioSource, seconds));
            return;
        }

        audioSource.Stop();
    }

    //AudioSource�̉��ʂ��t�F�[�h�A�E�g������֐�
    private IEnumerator VolumeFadeOut(AudioSource source, float seconds)
    {
        while (source.volume > 0)
        {
            source.volume -= (1.0f / 10.0f) / seconds;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        audioSource.Stop();
    }
}