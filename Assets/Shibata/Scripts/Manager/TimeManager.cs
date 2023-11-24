using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public int MaxTime { get; private set; } //�ő厞��
    public int CurrentTime { get; private set; } //���݂̎���
    public bool IsCounting { get; private set; } //�J�E���g���i��ł��邩

    public Action<int> onUpdateTimeCount; //�J�E���g���X�V���ꂽ�Ƃ��ɌĂ΂��C�x���g
    public Action onTimeCountZero; //�J�E���g���[���ɂȂ����Ƃ��ɌĂ΂��C�x���g

    protected override void Awake()
    {
        base.Awake();

        CurrentTime = MaxTime;
        StartCoroutine(TimeCountCoroutine());
    }

    //�J�E���g�̃X�^�[�g
    public void StartTimeCount()
    {
        IsCounting = true;
    }

    //�J�E���g�̃X�g�b�v
    public void StopTimeCount()
    {
        IsCounting = false;
    }

    //�J�E���g�̃R���[�`��
    private IEnumerator TimeCountCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!IsCounting) continue;
            --CurrentTime;
            onUpdateTimeCount?.Invoke(CurrentTime);
            if (CurrentTime <= 0)
            {
                onTimeCountZero?.Invoke();
                break;
            }
        }
    }
}
