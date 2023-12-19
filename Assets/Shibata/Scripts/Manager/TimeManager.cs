using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : Singleton<TimeManager>
{
    [field: SerializeField]public float MaxTime { get; private set; } //�ő厞��
    public float CurrentTime { get; private set; } //���݂̎���
    public bool IsCounting { get; set; } //�J�E���g���i��ł��邩

    [SerializeField] private Text endText;
    public Action<float> onUpdateTimeCount; //�J�E���g���X�V���ꂽ�Ƃ��ɌĂ΂��C�x���g
    public Action onTimeCountZero; //�J�E���g���[���ɂȂ����Ƃ��ɌĂ΂��C�x���g

    protected override void Awake()
    {
        base.Awake();

        CurrentTime = MaxTime;
    }

    private void Update()
    {
        if (!IsCounting) return;
        CurrentTime -= Time.deltaTime;
        onUpdateTimeCount?.Invoke(CurrentTime);
        if (CurrentTime <= 0)
        {
            onTimeCountZero?.Invoke();
            endText.gameObject.SetActive(true);
            IsCounting = false;
        }
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

}
