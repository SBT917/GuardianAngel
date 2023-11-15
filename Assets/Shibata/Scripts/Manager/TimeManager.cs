using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public int MaxTime { get; private set; } //最大時間
    public int CurrentTime { get; private set; } //現在の時間
    public bool IsCounting { get; private set; } //カウントが進んでいるか

    public Action<int> onUpdateTimeCount; //カウントが更新されたときに呼ばれるイベント
    public Action onTimeCountZero; //カウントがゼロになったときに呼ばれるイベント

    protected override void Awake()
    {
        base.Awake();

        CurrentTime = MaxTime;
        StartCoroutine(TimeCountCoroutine());
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

    //カウントのコルーチン
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
