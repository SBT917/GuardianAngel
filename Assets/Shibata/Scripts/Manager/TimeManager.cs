using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : Singleton<TimeManager>
{
    [field: SerializeField]public float MaxTime { get; private set; } //最大時間
    public float CurrentTime { get; private set; } //現在の時間
    public bool IsCounting { get; set; } //カウントが進んでいるか

    [SerializeField] private Text endText;
    public Action<float> onUpdateTimeCount; //カウントが更新されたときに呼ばれるイベント
    public Action onTimeCountZero; //カウントがゼロになったときに呼ばれるイベント

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

    //カウントのスタート
    public void StartTimeCount()
    {
        IsCounting = true;
    }

    //カウントのストップ
    public void StopTimeCount()
    {
        IsCounting = false;
    }

}
